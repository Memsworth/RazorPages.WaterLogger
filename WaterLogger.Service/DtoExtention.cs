using WaterLogger.Domain.Models;
using WaterLogger.Domain.Models.DTO;

namespace WaterLogger.Service;

public static class DtoExtention
{
    public static Water ToDbo(this WaterPostDto waterPostDto) => new Water()
    {
        Date = DateTime.Now,
        Quantity = waterPostDto.Quantity
    };
}