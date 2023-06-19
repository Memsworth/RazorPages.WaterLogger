using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RazorPages.WaterLogger.Data;

public class WaterLoggerDesignFactory : IDesignTimeDbContextFactory<WaterLoggerDbContext>
{
    public WaterLoggerDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var optionBuilder = new DbContextOptionsBuilder<WaterLoggerDbContext>();
        optionBuilder.UseSqlite(configuration.GetConnectionString("WaterLoggerDb"));

        return new WaterLoggerDbContext(optionBuilder.Options);
    }
}