using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class RegionConfig : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            var baseConfig = new BaseEntityConfig<Region>("Region", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");
        }
    }
}
