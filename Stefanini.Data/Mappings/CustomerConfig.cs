using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities;

namespace Stefanini.Data.Mappings
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var baseConfig = new BaseEntityConfig<Customer>("Customer", "dbo");
            baseConfig.Configure(ref builder);

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");
            
            builder.Property(p => p.Phone)
                .HasColumnName("Phone")
                .HasColumnType("varchar(50)");
            
            builder.Property(p => p.GenderId)
                .HasColumnName("GenderId")
                .HasColumnType("int");
            
            builder.Property(p => p.CityId)
                .HasColumnName("CityId")
                .HasColumnType("int");
            
            builder.Property(p => p.RegionId)
                .HasColumnName("RegionId")
                .HasColumnType("int");
            
            builder.Property(p => p.LastPurchase)
                .HasColumnName("LastPurchase")
                .HasColumnType("date");
            
            builder.Property(p => p.ClassificationId)
                .HasColumnName("ClassificationId")
                .HasColumnType("int");
            
            builder.Property(p => p.UserId)
                .HasColumnName("UserId")
                .HasColumnType("int");

        }
    }
}
