using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructure.NoSql.Configurations;

/// <summary>
/// Configuration for TicketModel.
/// </summary>
public sealed class TicketModelConfiguration : IEntityTypeConfiguration<TicketModel>
{
    public void Configure(EntityTypeBuilder<TicketModel> builder)
    {
        builder.ToCollection(nameof(TicketModel));
        
        builder.Property(x => x.SerialNumber)
            .IsRequired()
            .HasMaxLength(16);
        
        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.HasOne(x => x.Train)
            .WithMany(x => x.Tickets);
    }
}