
namespace Vehicles.Infrastructures.Models;

/// <summary>
/// Database model that describes Ticket entity.
/// </summary>
public class TicketModel
{
    /// <summary>
    /// The id of the Ticket.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// The Price of the Ticket.
    /// </summary>
    public required double Price { get; set; }
    
    /// <summary>
    /// The Serial Number of the Ticket.
    /// </summary>
    public required string SerialNumber { get; set; }

    /// <summary>
    /// Reference to Train entity.
    /// </summary>
    public TrainModel Train { get; set; } = null!;
}