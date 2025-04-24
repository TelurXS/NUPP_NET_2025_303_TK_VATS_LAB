using Newtonsoft.Json;
using Vehicles.Common.ValueObjects;

namespace Vehicles.Common.Entities;

/// <summary>
/// A sealed class that describes the Train entity.
/// </summary>
public sealed class Train : Vehicle
{
    private const string DEFAULT_NAME = "Train";
    private const string DEFAULT_COLOR = "Blue";
    private const int DEFAULT_CAPACITY = 120;
    private const LocomotiveType DEFAULT_LOCOMOTIVE = LocomotiveType.Diesel;
    
    /// <summary>
    /// Primary constructor.
    /// </summary>
    public Train()
        : this(Guid.CreateVersion7(), DEFAULT_NAME, DEFAULT_COLOR, DEFAULT_CAPACITY, DEFAULT_LOCOMOTIVE)
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
    
    /// <summary>
    /// Static method to create a new instance of Train.
    /// </summary>
    /// <returns>A new instance of Train.</returns>
    public static Train Create() => new();
    
    /// <summary>
    /// Static method to create a new instance of Train with parameters.
    /// </summary>
    /// <returns>A new instance of Train.</returns>
    public static Train Create(string name, string color, int capacity, LocomotiveType type)
        => new(Guid.CreateVersion7(), name, color, capacity, type);
}