using Microsoft.EntityFrameworkCore;
using WeighingScale.API.Model;

namespace WeighingScale.API.Data
{
    public class OrderWalaDbContext : DbContext
    {
        public OrderWalaDbContext(DbContextOptions<OrderWalaDbContext> options) : base(options)
        {
        }

        public DbSet<SalesRecord> SalesRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesRecord>(entity =>
            {
                entity.ToTable("sales_records");
                entity.HasKey(e => e.Id);
                entity.Property(a => a.CreatedAt).IsRequired();
            });
        }
    }
}
