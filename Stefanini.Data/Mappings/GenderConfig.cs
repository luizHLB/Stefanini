using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            var baseConfig = new BaseEntityConfig<Gender>("Gender", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");
        }
    }
}
