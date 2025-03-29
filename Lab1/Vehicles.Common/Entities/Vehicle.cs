using Newtonsoft.Json;

namespace Vehicles.Common.Entities;

/// <summary>
/// An abstract class that describes the Transport entity.
/// </summary>
public abstract class Vehicle
{
    private const string DEFAULT_NAME = "Vehicle";
    private const string DEFAULT_COLOR = "Black";
    private const int DEFAULT_CAPACITY = 4;

    private static int _vehiclesCount;

    /// <summary>
    /// Static constructor. Initializes _vehicleCount field;
    /// </summary>
    static Vehicle()
    {
        _vehiclesCount = 0;
    }
    
    /// <summary>
    /// Protected primary constructor.
    /// </summary>
    protected Vehicle() 
        : this(Guid.Empty, DEFAULT_NAME, DEFAULT_COLOR, DEFAULT_CAPACITY)
    {
    }

    /// <summary>
    /// Protected full constructor.
    /// </summary>
    protected Vehicle(Guid id, string name, string color, int capacity)
    {
        Id = id;
        Name = name;
        Color = color;
        Capacity = capacity;
        
        RecordVehicleCreated();
    }
    
    /// <summary>
    /// Count of Vehicles created.
    /// </summary>
    public static int VehiclesCount => _vehiclesCount;
    
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
    /// A delegate for StartedMoving event.
    /// </summary>
    public delegate void StartedMovingHandler(Vehicle vehicle);
    
    /// <summary>
    /// A delegate for StoppedMoving event.
    /// </summary>
    public delegate void StoppedMovingHandler(Vehicle vehicle);
    
    /// <summary>
    /// An event that occurs when a vehicle starts moving.
    /// </summary>
    /// <param>The vehicle that has started moving.</param>
    public event StartedMovingHandler StartedMoving;

    /// <summary>
    /// An event that occurs when a vehicle stopped moving.
    /// </summary>
    /// <param>The vehicle that has started moving.</param>
    public event StoppedMovingHandler StoppedMoving;

    /// <summary>
    /// Records that the Vehicle has been created.
    /// </summary>
    private static void RecordVehicleCreated()
    {
        _vehiclesCount++;
    }
    
    /// <summary>
    /// Ignores the record that the Vehicle was created. Used when copying a Vehicle.
    /// </summary>
    /// <param name="vehicle">The Vehicle to ignore record.</param>
    /// <returns>The Vehicle that was passed.</returns>
    public static T IgnoreCreatedRecording<T>(T vehicle) where T : Vehicle
    {
        _vehiclesCount--;
        return vehicle;
    }
    
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