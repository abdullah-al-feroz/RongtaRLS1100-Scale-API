using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeighingScale.API.Class;
using WeighingScale.API.Model;
using WeighingScale.API.Services;

namespace WeighingScale.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaleController : ControllerBase
    {
        private static int connid;
        private readonly ISalesService _salesService;

        public ScaleController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetSales()
        {
            ScaleNativeLoader.EnsureLoaded();

            connid = 0;
            int result = labelScale.rtscaleConnect("192.168.0.150", 0, ref connid);
            if (result != 0)
            {
                return BadRequest("Failed to connect scale");
            }

            SalesRecord? sale = null;
            labelScale.SaleDataCallback callback = (string sResult, int iRecNo, int aCount) =>
            {
                try
                {
                    var record = JsonConvert.DeserializeObject<SalesRecord>(sResult);
                    if (record != null && sale == null)
                    {
                        sale = record;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"JSON parse error: {ex.Message}");
                }
            };

            // upload sales data
            int count = labelScale.rtscaleUploadSaleData(connid, true, callback);

            // connection close
            labelScale.rtscaleDisConnect(connid);

            if (count < 0)
            {
                return BadRequest("Failed to get sales data");
            }

            if (sale == null)
            {
                return NotFound("No sales data found");
            }

            // Save to database
            try
            {
                var savedSale = await _salesService.SaveSalesRecordAsync(sale);
                return Ok(new
                {
                    message = "Sales data saved successfully",
                    sale = savedSale
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Failed to save sales data: {ex.Message}" });
            }
        }
    }
}
