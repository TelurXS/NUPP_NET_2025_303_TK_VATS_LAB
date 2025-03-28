using Newtonsoft.Json;

namespace Vehicles.Common;

/// <summary>
/// A sealed class that describes the Ticket entity.
/// </summary>
public sealed class Ticket
{
    /// <summary>
    /// Primary constructor.
    /// </summary>
    public Ticket()
        : this(Guid.Empty, 0, string.Empty)
    {
        
    }

    /// <summary>
    /// Full constructor.
    /// </summary>
    public Ticket(Guid id, double price, string serialNumber)
    {
        Id = id;
        Price = price;
        SerialNumber = serialNumber;
    }
    
    /// <summary>
    /// Full constructor.
    /// </summary>
    public Ticket(Ticket ticket)
        : this(ticket.Id, ticket.Price, ticket.SerialNumber)
    {
    }
    
    /// <summary>
    /// The id of the Ticket.
    /// </summary>
    [JsonProperty(nameof(Id))]
    public Guid Id { get; protected set; }

    /// <summary>
    /// The Price of the Ticket.
    /// </summary>
    [JsonProperty(nameof(Price))]
    public double Price { get; protected set; }
    
    /// <summary>
    /// The Serial Number of the Ticket.
    /// </summary>
    [JsonProperty(nameof(SerialNumber))]
    public string SerialNumber { get; protected set; }
}