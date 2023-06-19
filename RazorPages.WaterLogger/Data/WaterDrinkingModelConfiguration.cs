using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorPages.WaterLogger.Models;

namespace RazorPages.WaterLogger.Data;

public class WaterDrinkingModelConfiguration : IEntityTypeConfiguration<DrinkingWaterModel>
{
    public void Configure(EntityTypeBuilder<DrinkingWaterModel> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Quantity).IsRequired();
    }
}