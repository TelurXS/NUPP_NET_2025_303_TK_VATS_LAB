using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Configurations;

/// <summary>
/// Configuration for TicketModel.
/// </summary>
public sealed class TicketModelConfiguration : IEntityTypeConfiguration<TicketModel>
{
    public void Configure(EntityTypeBuilder<TicketModel> builder)
    {
        builder.HasIndex(x => x.Id)
            .IsUnique();
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.SerialNumber)
            .IsRequired()
            .HasMaxLength(16);
        
        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.HasOne(x => x.Train)
            .WithMany(x => x.Tickets);
    }
}