using Microsoft.EntityFrameworkCore;
using RazorPages.WaterLogger.Models;

namespace RazorPages.WaterLogger.Data;

public class WaterLoggerDbContext : DbContext
{
    public WaterLoggerDbContext(DbContextOptions options) : base(options)
    { }
    
    public virtual DbSet<DrinkingWaterModel> DrinkingSchedule { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WaterDrinkingModelConfiguration());
    }
}