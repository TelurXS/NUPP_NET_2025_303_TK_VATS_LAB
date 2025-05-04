using Newtonsoft.Json;

namespace Vehicles.Common.Entities;

public sealed class TrainRoute
{
    /// <summary>
    /// Full constructor.
    /// </summary>
    public TrainRoute(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Primary constructor.
    /// </summary>
    public TrainRoute() : this(Guid.CreateVersion7(), string.Empty)
    {
    }
    
    /// <summary>
    /// The id of the Route.
    /// </summary>
    [JsonProperty(nameof(Id))]
    public Guid Id { get; private set; }
    
    /// <summary>
    /// The name of the Route.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; private set; }
}