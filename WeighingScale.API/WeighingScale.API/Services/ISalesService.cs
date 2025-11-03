using WeighingScale.API.Model;

namespace WeighingScale.API.Services
{
    public interface ISalesService
    {
        Task<SalesRecord> SaveSalesRecordAsync(SalesRecord salesRecord);
    }
}
