using WeighingScale.API.Data;
using WeighingScale.API.Model;
using WeighingScale.API.Services;

namespace WeighingScale.API.Repository
{
    public class SalesService : ISalesService
    {
        private readonly OrderWalaDbContext _context;

        public SalesService(OrderWalaDbContext context)
        {
            _context = context;
        }

        public async Task<SalesRecord> SaveSalesRecordAsync(SalesRecord salesRecord)
        {
            salesRecord.Id = 0;
            salesRecord.CreatedAt = DateTime.UtcNow;

            _context.SalesRecords.Add(salesRecord);
            await _context.SaveChangesAsync();
            return salesRecord;
        }
    }
}
