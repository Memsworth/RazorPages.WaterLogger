using System.ComponentModel.DataAnnotations;

namespace WaterLogger.Domain.Models.DTO;

public class WaterPostDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
    public int Quantity { get; set; }
}