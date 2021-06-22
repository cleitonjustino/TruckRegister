using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegister.Entities;

namespace TruckRegister.Repository.Mapping
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.YearOfManufacture);
            builder.HasOne(bc => bc.ModelTruck)
              .WithMany(b => b.Trucks)
              .HasForeignKey(bc => bc.IdModel);
        }
    }
}
