using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterLogger.Domain.Models;

namespace WaterLogger.DataAccess.Configurations;

public class WaterItemConfiguration : IEntityTypeConfiguration<Water>
{
    public void Configure(EntityTypeBuilder<Water> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.Quantity).IsRequired();
    }
}