using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructure.NoSql.Configurations;

/// <summary>
/// Configuration for TrainRouteModel. 
/// </summary>
public sealed class TrainRouteModelConfiguration : IEntityTypeConfiguration<TrainRouteModel>
{
    public void Configure(EntityTypeBuilder<TrainRouteModel> builder)
    {
        builder.ToCollection(nameof(TrainRouteModel));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(128);
        
        builder.HasMany(x => x.Trains)
            .WithMany(x => x.Routes);
    }
}