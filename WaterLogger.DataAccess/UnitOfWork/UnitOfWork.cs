using WaterLogger.Domain.Abstraction.Repositories;
using WaterLogger.Domain.Abstraction.UnitOfWork;

namespace WaterLogger.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IWaterLoggerRepository WaterLoggerRepository { get; }

    //TODO
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task CommitAsync()
    {
        throw new NotImplementedException();
    }
}