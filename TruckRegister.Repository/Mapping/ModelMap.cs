using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegister.Entities;

namespace TruckRegister.Repository.Mapping
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.ModelDescription);
            builder.Property(t => t.YearOfModel);
        }
    }
}
