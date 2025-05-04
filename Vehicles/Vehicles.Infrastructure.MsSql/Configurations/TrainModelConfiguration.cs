using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Configurations;

/// <summary>
/// Configuration for TrainModel. 
/// </summary>
public sealed class TrainModelConfiguration : IEntityTypeConfiguration<TrainModel>
{
    public void Configure(EntityTypeBuilder<TrainModel> builder)
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
        
        builder.Property(x => x.Capacity)
            .IsRequired();
        
        builder.Property(x => x.Type)
            .IsRequired();
        
        builder.HasMany(x => x.Tickets)
            .WithOne(x => x.Train);
        
        builder.HasMany(x => x.Routes)
            .WithMany(x => x.Trains);
    }
}