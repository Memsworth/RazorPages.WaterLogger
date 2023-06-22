using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Abstraction.UnitOfWork;
using WaterLogger.Domain.Models;

namespace WaterLogger.Service;

public class WaterService : IWaterService
{
    protected readonly IUnitOfWork _unitOfWork;
    public WaterService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;


    public async Task<Water> GetExerciseByIdAsync(int id) => await _unitOfWork.WaterLoggerRepository.GetAsync(id);

    public async Task<List<Water>> GetAllExerciseAsync() => await _unitOfWork.WaterLoggerRepository.GetAsync();

    public async Task AddExerciseAsync(Water waterItem)
    {
        await _unitOfWork.WaterLoggerRepository.AddAsync(waterItem);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateExerciseAsync(Water waterItem, Water waterUpdate)
    {
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteExerciseAsync(Water waterItem)
    {
        _unitOfWork.WaterLoggerRepository.Delete(waterItem);
        await _unitOfWork.CommitAsync();
    }
}