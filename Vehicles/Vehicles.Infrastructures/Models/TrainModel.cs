using Vehicles.Common.ValueObjects;

namespace Vehicles.Infrastructures.Models;

/// <summary>
/// Database model that describes Train entity.
/// </summary>
public sealed class TrainModel
{
    /// <summary>
    /// The id of a Vehicle.
    /// </summary>
    public required Guid Id { get; set; }
    
    /// <summary>
    /// The Name of a Vehicle.
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// The Color of a Vehicle.
    /// </summary>
    public required string Color { get; set; }
    
    /// <summary>
    /// The Passenger Capacity of a Vehicle. Describes how many passengers can
    /// fit in a Vehicle.
    /// </summary>
    public required int Capacity { get; set; }
    
    /// <summary>
    /// The Locomotive type of the Train.
    /// </summary>
    public required LocomotiveType Type { get; set; }

    /// <summary>
    /// Reference to Tickets to this Train
    /// </summary>
    public ICollection<TicketModel> Tickets { get; set; } = null!;

    /// <summary>
    /// Reference to Routes of the Train
    /// </summary>
    public ICollection<TrainRouteModel> Routes { get; set; } = null!;
}