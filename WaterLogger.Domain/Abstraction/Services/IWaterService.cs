using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Domain.Abstraction.Services;

public interface IWaterService
{
    Task<Water> GetWaterByIdAsync(int id);
    Task<List<Water>> GetAllWaterAsync();
    Task AddWaterAsync(WaterPostDto waterItemPostDto);
    Task UpdateWaterAsync(Water waterItem, Water waterUpdate);
    Task DeleteWaterAsync(Water waterItem);
}