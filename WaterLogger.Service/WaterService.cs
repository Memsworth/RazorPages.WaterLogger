using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Abstraction.UnitOfWork;
using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Service;

public class WaterService : IWaterService
{
    protected readonly IUnitOfWork _unitOfWork;
    public WaterService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


    public async Task<Water> GetWaterByIdAsync(int id) => await _unitOfWork.WaterLoggerRepository.GetAsync(id);

    public async Task<List<Water>> GetAllWaterAsync() => await _unitOfWork.WaterLoggerRepository.GetAsync();

    public async Task AddWaterAsync(WaterPostDto waterItemPostDto)
    {
        await _unitOfWork.WaterLoggerRepository.AddAsync(waterItemPostDto.ToDbo());
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateWaterAsync(Water waterItem, Water waterUpdate)
    {
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteWaterAsync(Water waterItem)
    {
        _unitOfWork.WaterLoggerRepository.Delete(waterItem);
        await _unitOfWork.CommitAsync();
    }
}