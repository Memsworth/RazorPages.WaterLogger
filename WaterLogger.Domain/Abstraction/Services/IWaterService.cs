using WaterLogger.Domain.Models;

namespace WaterLogger.Domain.Abstraction.Services;

public interface IWaterService
{
    Task<Water> GetExerciseByIdAsync(int id);
    Task<List<Water>> GetAllExerciseAsync();
    Task AddExerciseAsync(Water waterItem);
    Task UpdateExerciseAsync(Water waterItem, Water waterUpdate);
    Task DeleteExerciseAsync(Water waterItem);
}