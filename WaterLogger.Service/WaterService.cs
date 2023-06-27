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
                { Status = ResponseStatus.BadRequest, Message = "User not found" };
            }

            return new ServiceResponse<Water>
                { Status = ResponseStatus.Success, Data = item };
        }
        catch (Exception e)
        {
            return new ServiceResponse<Water> { Status = ResponseStatus.Error, Message = e.Message };
        }
    }

    public async Task<ServiceResponse<IEnumerable<Water>>> GetAllWaterAsync()
    {
        try
        {
            var items = await _unitOfWork.WaterLoggerRepository.GetAsync();
            return new ServiceResponse<IEnumerable<Water>>
                { Status = ResponseStatus.Success, Data = items };
        }
        catch (Exception e)
        {
            return new ServiceResponse<IEnumerable<Water>>
                { Status = ResponseStatus.Error, Message = e.Message };
        }
    }

    public async Task<ServiceResponse<int>> AddWaterAsync(WaterPostDto waterItem)
    {
        try
        {
            await _unitOfWork.WaterLoggerRepository.AddAsync(waterItem.ToDbo());
            await _unitOfWork.CommitAsync();
            return new ServiceResponse<int>
                { Status = ResponseStatus.Success, Message = "Item Inserted" };
        }
        catch (Exception e)
        {
            return new ServiceResponse<int>
                { Status = ResponseStatus.Error, Message = e.Message };
        }
    }

    public async Task<ServiceResponse<int>> UpdateWaterAsync(Water waterItem)
    {
        try
        {
            _unitOfWork.WaterLoggerRepository.Update(waterItem);
            await _unitOfWork.CommitAsync();
            return new ServiceResponse<int>()
            { Status = ResponseStatus.Success, Message = "Item Updated"};
        }
        catch (Exception e)
        {
            return new ServiceResponse<int>
                { Status = ResponseStatus.Error, Message = e.Message };
        }
    }

    public async Task<ServiceResponse<int>> DeleteWaterAsync(Water waterItem)
    {
        try
        {
            _unitOfWork.WaterLoggerRepository.Delete(waterItem);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<int>
            { Status = ResponseStatus.Success, Message = "Item is deleted" };
        }
        catch (Exception e)
        {
            return new ServiceResponse<int>()
                { Status = ResponseStatus.Error, Message = e.Message };
        }
    }
}