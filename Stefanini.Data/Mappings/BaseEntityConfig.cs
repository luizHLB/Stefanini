using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Domain.Entities.Base;

namespace Stefanini.Data.Mappings
{
    public class BaseEntityConfig<T> where T : BaseEntity
    {
        public BaseEntityConfig(string table, string schema)
        {
            Table = table;
            Schema = schema;
        }

        public string Table { get; }
        public string Schema { get; }

        public void Configure(ref EntityTypeBuilder<T> builder)
        {
            builder.ToTable(Table, Schema);

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnType("int");
        }
    }
}
