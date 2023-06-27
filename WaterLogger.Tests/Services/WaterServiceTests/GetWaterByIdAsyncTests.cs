using WaterLogger.Domain.Models;

namespace WaterLogger.Tests.Services.WaterServiceTests;

public class GetWaterByIdAsyncTests : BaseWaterServiceTest
{
    private const int Id = 65;

    [Fact]
    public async Task Ensure_we_can_get_water_by_id()
    {
        var expected = GetWater(Id);
        Waters.Add(expected);

        var response = await Sut.GetWaterByIdAsync(Id);

        Assert.Equal(ResponseStatus.Success, response.Status);
        Assert.Equal(expected, response.Data);
    }

    [Fact]
    public async Task Ensure_if_not_found_we_report()
    {
        var response = await Sut.GetWaterByIdAsync(Id);

        Assert.Equal(ResponseStatus.BadRequest, response.Status);
        Assert.Equal("User not found", response.Message);
    }

    [Fact]
    public async Task Ensure_on_error_we_report()
    {
        var exception = new Exception(Guid.NewGuid().ToString());
        MockUnitOfWork.Setup(w => w.WaterLoggerRepository).Throws(exception);

        var response = await Sut.GetWaterByIdAsync(Id);

        Assert.Equal(ResponseStatus.Error, response.Status);
        Assert.Contains(exception.Message, response.Message);
    }
}