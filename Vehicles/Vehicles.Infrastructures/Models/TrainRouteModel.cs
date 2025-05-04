namespace Vehicles.Infrastructures.Models;

/// <summary>
/// Database model that describes Train Route entity.
/// </summary>
public sealed class TrainRouteModel
{
    /// <summary>
    /// The id of the Route.
    /// </summary>
    public required Guid Id { get; set; }
    
    /// <summary>
    /// The name of the Route.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Reference to Trains that rides on that Route.
    /// </summary>
    public ICollection<TrainModel> Trains { get; set; } = null!;
}