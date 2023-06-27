using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Domain.Abstraction.Services;

public interface IWaterService
{
    Task<ServiceResponse<Water>> GetWaterByIdAsync(int id);
    Task<ServiceResponse<IEnumerable<Water>>> GetAllWaterAsync();
    Task<ServiceResponse<int>> AddWaterAsync(WaterPostDto waterItem);
    Task<ServiceResponse<int>> UpdateWaterAsync(Water waterItem);
    Task<ServiceResponse<int>> DeleteWaterAsync(Water waterItem);
}