using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Configurations;

/// <summary>
/// Configuration for TrainRouteModel. 
/// </summary>
public sealed class TrainRouteModelConfiguration : IEntityTypeConfiguration<TrainRouteModel>
{
    public void Configure(EntityTypeBuilder<TrainRouteModel> builder)
    {
        builder.HasIndex(x => x.Id)
            .IsUnique();
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(128);
        
        builder.HasMany(x => x.Trains)
            .WithMany(x => x.Routes);
    }
}