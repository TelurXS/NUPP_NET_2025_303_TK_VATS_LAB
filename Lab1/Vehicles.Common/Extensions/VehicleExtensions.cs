using Vehicles.Common.Entities;

namespace Vehicles.Common.Extensions;

/// <summary>
/// Static class for <see cref="Vehicle"/> extensions.
/// </summary>
public static class VehicleExtensions
{
    /// <summary>
    /// Represents the <see cref="Vehicle"/> as detailed string in format "Vehicle({id}): {name} {color} {capacity}"
    /// </summary>
    /// <param name="vehicle">The Vehicle to represent.</param>
    /// <returns>A string representation of the Vehicle.</returns>
    public static string ToDetailedString(this Vehicle vehicle)
        => $"Vehicle({vehicle.Id}): {vehicle.Name} {vehicle.Color} {vehicle.Capacity}";
}