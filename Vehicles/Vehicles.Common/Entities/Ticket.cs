using Newtonsoft.Json;

namespace Vehicles.Common.Entities;

/// <summary>
/// A sealed class that describes the Ticket entity.
/// </summary>
public sealed class Ticket
{
    /// <summary>
    /// Primary constructor.
    /// </summary>
    public Ticket()
        : this(Guid.CreateVersion7(), 0, string.Empty)
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
    public Guid Id { get; private set; }

    /// <summary>
    /// The Price of the Ticket.
    /// </summary>
    [JsonProperty(nameof(Price))]
    public double Price { get; private set; }
    
    /// <summary>
    /// The Serial Number of the Ticket.
    /// </summary>
    [JsonProperty(nameof(SerialNumber))]
    public string SerialNumber { get; private set; }

    /// <summary>
    /// An event that occurs when price of Ticket is changed.
    /// </summary>
    public event Action<Ticket> PriceChanged;

    /// <summary>
    /// Updates price of the Ticket.
    /// </summary>
    /// <param name="value">Price value to change.</param>
    public void UpdatePrice(double value)
    {
        Price = value;
        PriceChanged?.Invoke(this);
    }
    
    /// <summary>
    /// Static method to create a new instance of Ticket.
    /// </summary>
    /// <returns>A new instance of Ticket.</returns>
    public static Ticket Create() => new();
    
    /// <summary>
    /// Static method to create a new instance of Ticket with parameters.
    /// </summary>
    /// <returns>A new instance of Train.</returns>
    public static Ticket Create(double price, string serialNumber) 
        => new(Guid.CreateVersion7(), price, serialNumber);
}