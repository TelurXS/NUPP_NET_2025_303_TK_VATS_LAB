using Newtonsoft.Json;

namespace Vehicles.Common;

/// <summary>
/// A sealed class that describes the Train entity.
/// </summary>
public sealed class Train : Vehicle
{
    public enum LocomotiveType
    {
        Steam,
        InternalCombustion,
        Diesel,
        Electric,
        DirectCurrent,
        AlternatingCurrent,
        BatteryElectric,
        Other,
    }
    
    private const string DEFAULT_NAME = "Train";
    private const string DEFAULT_COLOR = "Blue";
    private const int DEFAULT_CAPACITY = 120;
    private const LocomotiveType DEFAULT_LOCOMOTIVE = LocomotiveType.Diesel;
    
    /// <summary>
    /// Primary constructor.
    /// </summary>
    public Train()
        : this(Guid.Empty, DEFAULT_NAME, DEFAULT_COLOR, DEFAULT_CAPACITY, DEFAULT_LOCOMOTIVE)
    {
    }

    /// <summary>
    /// Full constructor.
    /// </summary>
    public Train(Guid  id, string name, string color, int capacity, LocomotiveType type)
        : base(id, name, color, capacity)
    {
        Type = type;
    }
    
    /// <summary>
    /// Copy constructor.
    /// </summary>
    public Train(Train train)
        : this(train.Id, train.Name, train.Color, train.Capacity, train.Type)
    {
    }
    
    [JsonProperty(nameof(Type))]
    public LocomotiveType Type { get; private set; }

    /// <summary>
    /// Prints a 'chu chu chu chu chu' message to console.
    /// </summary>
    public void ChuChu()
    {
        Console.WriteLine($"Chu chu chu chu chu");
    }
}