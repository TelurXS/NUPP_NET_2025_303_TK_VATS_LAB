namespace Vehicles.Infrastructures.Models;

/// <summary>
/// Database model that describes Bus entity.
/// </summary>
public class BusModel
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
    /// The Route of the Bus.
    /// </summary>
    public required string Route { get; set; }
}