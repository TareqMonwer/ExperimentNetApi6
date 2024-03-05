using Microsoft.EntityFrameworkCore;

namespace ExperimentNetApi6.Data
{
  public class ExperimentNetApi6Context : DbContext
  {
    public DbSet<Weather> Weather { get; set; }

    public ExperimentNetApi6Context(DbContextOptions<ExperimentNetApi6Context> config) : base(config)
    {
    }

  }
}
