using System.ComponentModel.DataAnnotations;

namespace WaterLogger.Domain.Models;

// asdadsa 
public class Water : DbBaseModel
{
    public DateTime Date { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number")]
    public int Quantity { get; set; }
}