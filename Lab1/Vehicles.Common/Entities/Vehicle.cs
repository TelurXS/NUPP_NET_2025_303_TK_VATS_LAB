using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace Vehicles.Common;

/// <summary>
/// An abstract class that describes the Transport entity.
/// </summary>
public abstract class Vehicle
{
    private const string DEFAULT_NAME = "Vehicle";
    private const string DEFAULT_COLOR = "Black";
    private const int DEFAULT_CAPACITY = 4;
    
    protected Vehicle() 
        : this(Guid.Empty, DEFAULT_NAME, DEFAULT_COLOR, DEFAULT_CAPACITY)
    {
    }

    protected Vehicle(Guid id, string name, string color, int capacity)
    {
        Id = id;
        Name = name;
        Color = color;
        Capacity = capacity;
    }
    
    /// <summary>
    /// The id of a Vehicle.
    /// </summary>
    [JsonProperty(nameof(Id))]
    public Guid Id { get; protected set; }
    
    /// <summary>
    /// The Name of a Vehicle.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; protected set; }
    
    /// <summary>
    /// The Color of a Vehicle.
    /// </summary>
    [JsonProperty(nameof(Color))]
    public string Color { get; protected set; }
    
    /// <summary>
    /// The Passenger Capacity of a Vehicle. Describes how many passengers can
    /// fit in a Vehicle.
    /// </summary>
    [JsonProperty(nameof(Capacity))]
    public int Capacity { get; protected set; }
    
    /// <summary>
    /// An event delegate that  occurs when a vehicle starts moving.
    /// </summary>
    /// <param>The vehicle that has started moving.</param>
    public event Action<Vehicle> StartedMoving;

    /// <summary>
    /// An event delegate that occurs when a vehicle stopped moving.
    /// </summary>
    /// <param>The vehicle that has started moving.</param>
    public event Action<Vehicle> StoppedMoving;

    /// <summary>
    /// Changes the color of the Vehicle.
    /// </summary>
    /// <param name="value">The color name.</param>
    public virtual void Paint(string value)
    {
        Color = value;
    }
    
    /// <inheritdoc/>
    public override string ToString()
        => $"Vehicle({Id}): {Name}";
}