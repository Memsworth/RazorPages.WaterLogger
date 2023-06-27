using Moq;
using WaterLogger.Domain.Abstraction.Repositories;
using WaterLogger.Domain.Abstraction.UnitOfWork;
using WaterLogger.Domain.Models;
using WaterLogger.Service;

namespace WaterLogger.Tests.Services.WaterServiceTests;

public class BaseWaterServiceTest
{
    protected WaterService Sut;

    protected readonly Mock<IUnitOfWork> MockUnitOfWork;
    private readonly Mock<IWaterLoggerRepository> _mockWaterLoggerRepository = new();

    protected readonly List<Water> Waters = new();

    public BaseWaterServiceTest()
    {
        MockUnitOfWork = new Mock<IUnitOfWork>();
        MockUnitOfWork.Setup(w => w.WaterLoggerRepository)
            .Returns(_mockWaterLoggerRepository.Object);

        Sut = new WaterService(MockUnitOfWork.Object);

        SetupMocks(_mockWaterLoggerRepository, Waters);
    }

    protected static Water GetWater(int id) => new() { Id = id, Date = DateTime.Now, Quantity = Random.Shared.Next(0, 100) };


    private static void SetupMocks<TBaseRepo, T>(Mock<TBaseRepo> mock, List<T> referenceList)
        where TBaseRepo : class, IBaseRepository<T>
        where T : DbBaseModel
    {
        mock.Setup(w => w.GetAsync(It.IsAny<int>())).ReturnsAsync((int i) => referenceList.FirstOrDefault(q => q.Id == i));
        mock.Setup(w => w.Delete(It.IsAny<T>()))
            .Callback((T w) => referenceList = referenceList.Where(q => q.Id != w.Id).ToList());

        mock.Setup(w => w.Update(It.IsAny<T>()))
            .Callback((T w) =>
            {
                var item = referenceList.FirstOrDefault(q => q.Id != w.Id);
                if (item is null) return;
                referenceList.Remove(item);
                referenceList.Add(w);
            });

        mock.Setup(w => w.AddAsync(It.IsAny<T>()))
            .Callback((T w) => referenceList.Add(w));
    }
}