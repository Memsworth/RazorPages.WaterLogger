using Moq;
using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Tests.Services.WaterServiceTests;

public class AddWaterAsyncTests : BaseWaterServiceTest
{
    [Fact]
    public async Task Ensure_we_can_get_water_by_id()
    {
        var dto = new WaterPostDto { Quantity = 52 };

        var response = await Sut.AddWaterAsync(dto);


        MockUnitOfWork.Verify(w => w.CommitAsync(), Times.Once);
        Assert.Equal(ResponseStatus.Success, response.Status);
        Assert.Equal(1, Waters.Count(w => w.Quantity == dto.Quantity));
    }


    [Fact]
    public async Task Ensure_on_error_we_report()
    {
        var exception = new Exception(Guid.NewGuid().ToString());
        MockUnitOfWork.Setup(w => w.CommitAsync()).Throws(exception);
        var dto = new WaterPostDto { Quantity = 52 };

        var response = await Sut.AddWaterAsync(dto);

        Assert.Equal(ResponseStatus.Error, response.Status);
        Assert.Contains(exception.Message, response.Message);
    }
}