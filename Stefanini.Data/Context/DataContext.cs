using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Mappings;

namespace Stefanini.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(new DbContextOptionsBuilder<DbContext>().UseSqlServer(new SqlConnection(@"Data Source=localhost\sqlservertheos;Initial Catalog=DATABASE;User ID=sa;Password=sys@36911")).Options)
        { 
        }

        //public DataContext(DbContextOptionsBuilder<DbContext> optionsBuilder) : base(optionsBuilder.Options)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new RegionConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new GenderConfig());
            modelBuilder.ApplyConfiguration(new ClassificationConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
