using WaterLogger.DataAccess.Repositories;
using WaterLogger.Domain.Abstraction.Repositories;
using WaterLogger.Domain.Abstraction.UnitOfWork;

namespace WaterLogger.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    protected readonly WaterLoggerDbContext DbContext;
    public IWaterLoggerRepository WaterLoggerRepository { get; private set; }

    public UnitOfWork(WaterLoggerDbContext dbContext, IWaterLoggerRepository waterLoggerRepository)
    {
        DbContext = dbContext;
        WaterLoggerRepository = new WaterLoggerRepository(DbContext);
    }
    public void Dispose() => DbContext.Dispose();
    public async Task CommitAsync() => await DbContext.SaveChangesAsync();
}