using Newtonsoft.Json;

namespace Vehicles.Common;

/// <summary>
/// A sealed class that describes the Bus entity.
/// </summary>
public sealed class Bus :  Vehicle
{
    private const string DEFAULT_NAME = "Bus";
    private const string DEFAULT_COLOR = "Yellow";
    private const int DEFAULT_CAPACITY = 30;
    private const string DEFAULT_ROUTE = "23";
    
    /// <summary>
    /// Primary constructor.
    /// </summary>
    public Bus() 
        : this(Guid.Empty, DEFAULT_NAME, DEFAULT_CAPACITY, DEFAULT_ROUTE)
    {
    }

    /// <summary>
    /// Full constructor.
    /// </summary>
    public Bus(Guid id, string name, int capacity, string route ) 
        : base(id, name, DEFAULT_COLOR, capacity)
    {
        Route = route;
    }
    
    /// <summary>
    /// Copy constructor.
    /// </summary>
    public Bus(Bus bus)
        : this(bus.Id, bus.Name, bus.Capacity, bus.Route)
    {
    }
    
    /// <summary>
    /// The Route of the Bus.
    /// </summary>
    [JsonProperty(nameof(Route))]
    public string Route { get; private set;}

    public override void Paint(string value)
    {
        throw new InvalidOperationException("You cannot paint the bus. Busses should always be yellow.");
    }
}