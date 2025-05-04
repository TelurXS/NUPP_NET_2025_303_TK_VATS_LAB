using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Configurations;

/// <summary>
/// Configuration for BusModel. 
/// </summary>
public sealed class BusModelConfiguration : IEntityTypeConfiguration<BusModel>
{
    public void Configure(EntityTypeBuilder<BusModel> builder)
    {
        builder.HasIndex(x => x.Id)
            .IsUnique();
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(128);
        
        builder.Property(x => x.Color)
            .IsRequired()
            .HasMaxLength(128);
        
        builder.Property(x => x.Route)
            .IsRequired()
            .HasMaxLength(128);
        
        builder.Property(x => x.Capacity)
            .IsRequired();
    }
}