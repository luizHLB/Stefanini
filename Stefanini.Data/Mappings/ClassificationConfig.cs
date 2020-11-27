using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class ClassificationConfig : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            var baseConfig = new BaseEntityConfig<Classification>("Classification", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");
        }
    }
}
