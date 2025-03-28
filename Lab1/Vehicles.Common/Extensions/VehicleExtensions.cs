namespace Vehicles.Common.Extensions;

public static class VehicleExtensions
{
    public static string ToDetailedString(this Vehicle vehicle)
        => $"Vehicle({vehicle.Id}): {vehicle.Name} {vehicle.Color} {vehicle.Capacity}";
}