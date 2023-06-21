using WaterLogger.Domain.Abstraction.Repositories;
using WaterLogger.Domain.Models;

namespace WaterLogger.DataAccess.Repositories;

public class WaterLoggerRepository : BaseRepository<Water>, IWaterLoggerRepository
{
    public WaterLoggerRepository(WaterLoggerDbContext dbContext) : base(dbContext)
    {
    }
}