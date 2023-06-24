using Microsoft.EntityFrameworkCore.Metadata;
using WaterLogger.Domain.Abstraction.Services;
using WaterLogger.Domain.Abstraction.UnitOfWork;
using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Service;

public class WaterService : IWaterService
{
    protected readonly IUnitOfWork _unitOfWork;
    public WaterService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ServiceResponse<Water>> GetWaterByIdAsync(int id)
    {
        try
        {
            var item = await _unitOfWork.WaterLoggerRepository.GetAsync(id);
            if (item is null)
            {
                return new ServiceResponse<Water>
                { Status = ServiceStatus.BadRequest, Message = "User not found" };
            }

            return new ServiceResponse<Water>
                { Status = ServiceStatus.Success, Data = item };
        }
        catch (Exception e)
        {
            return new ServiceResponse<Water> { Status = ServiceStatus.Error, Message = e.Message };
        }
    }

    public async Task<ServiceResponse<IEnumerable<Water>>> GetAllWaterAsync()
    {
        try
        {
            var items = await _unitOfWork.WaterLoggerRepository.GetAsync();
            
            return new ServiceResponse<IEnumerable<Water>>
                { Status = ServiceStatus.Success, Data = items };
        }
        catch (Exception e)
        {
            return new ServiceResponse<IEnumerable<Water>>
                { Status = ServiceStatus.Error, Message = e.Message };
        }
    }

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