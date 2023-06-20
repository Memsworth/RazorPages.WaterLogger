using Microsoft.EntityFrameworkCore;
using WaterLogger.DataAccess.Configurations;
using WaterLogger.Domain.Models;

namespace WaterLogger.DataAccess;

public class WaterLoggerDbContext : DbContext
{
    public WaterLoggerDbContext(DbContextOptions options) : base (options)
    { }
    
    public virtual DbSet<Water> WaterLog { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WaterItemConfiguration());
    }
}