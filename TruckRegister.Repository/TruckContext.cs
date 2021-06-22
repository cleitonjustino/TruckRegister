using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TruckRegister.Entities;
using TruckRegister.Repository.Mapping;

namespace TruckRegister.Repository
{
    public class TruckContext :DbContext
    {
        private readonly ILogger<TruckContext> _logger;
        public DbSet<Truck> Truck { get; set; }
        public TruckContext(DbContextOptions<TruckContext> options)
        : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _logger.Log(LogLevel.Information, "OnModelCreating...");
            modelBuilder.ApplyConfiguration(new TruckMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
        }
    }
}
