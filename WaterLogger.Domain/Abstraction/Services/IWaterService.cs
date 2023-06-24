using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Domain.Abstraction.Services;

public interface IWaterService
{
    Task<ServiceResponse<Water>> GetWaterByIdAsync(int id);
    Task<ServiceResponse<IEnumerable<Water>>> GetAllWaterAsync();
    Task<ServiceResponse<int>> AddWaterAsync(WaterPostDto waterItem);
    Task UpdateWaterAsync(Water waterItem, Water waterUpdate);
    Task DeleteWaterAsync(Water waterItem);
}