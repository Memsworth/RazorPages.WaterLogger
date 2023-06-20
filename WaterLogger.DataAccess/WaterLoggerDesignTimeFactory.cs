using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WaterLogger.DataAccess;

public class WaterLoggerDesignTimeFactory : IDesignTimeDbContextFactory<WaterLoggerDbContext>
{
    public WaterLoggerDbContext CreateDbContext(string[] args)
    {
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        if (string.IsNullOrEmpty(folderPath))
        {
            throw new ArgumentNullException();
        }

        var dbPath = Path.Join(folderPath, "waterLogger.db");
        if (string.IsNullOrEmpty(dbPath))
        {
            throw new ArgumentNullException();
        }

        var optionBuilder = new DbContextOptionsBuilder<WaterLoggerDbContext>();
        optionBuilder.UseSqlite($"Data Source={dbPath}");

        return new WaterLoggerDbContext(optionBuilder.Options);
    }
}