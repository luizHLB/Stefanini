using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            var baseConfig = new BaseEntityConfig<City>("City", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");

            builder.Property(p => p.RegionId)
                .HasColumnName("RegionId")
                .HasColumnType("int");
        }
    }
}
