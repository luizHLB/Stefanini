using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            var baseConfig = new BaseEntityConfig<UserRole>("UserRole", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(20)");

            builder.Property(p => p.IsAdmin)
                .HasColumnName("IsAdmin")
                .HasColumnType("bit");
        }
    }
}
