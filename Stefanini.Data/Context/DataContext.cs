using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stefanini.Data.Mappings;

namespace Stefanini.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(IConfiguration configuration) : base(new DbContextOptionsBuilder<DbContext>().UseSqlServer(configuration.GetConnectionString("DATABASE")).Options)
        {
        }

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
