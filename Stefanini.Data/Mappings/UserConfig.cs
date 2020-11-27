using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var baseConfig = new BaseEntityConfig<User>("UserSys", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar(40)");

            builder.Property(p => p.UserRoleId)
                .HasColumnName("UserRoleId")
                .HasColumnType("int");
        }
    }
}
