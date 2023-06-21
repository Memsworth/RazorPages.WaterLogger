using WaterLogger.Domain.Abstraction.Repositories;

namespace WaterLogger.Domain.Abstraction.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IWaterLoggerRepository WaterLoggerRepository { get; }
    Task CommitAsync();
}