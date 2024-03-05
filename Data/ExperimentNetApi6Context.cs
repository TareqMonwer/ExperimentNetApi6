using Microsoft.EntityFrameworkCore;

namespace ExperimentNetApi6.Data
{
    public class ExperimentNetApi6Context : DbContext
    {
        IConfiguration appConfig;

        public DbSet<Weather> Weather { get; set; }

        public ExperimentNetApi6Context(IConfiguration config)
        {
            appConfig = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfig.GetConnectionString("ExperminetNet6"));
        }

    }
}
