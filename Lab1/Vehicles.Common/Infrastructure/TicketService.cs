using Vehicles.Common.Entities;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An in-memory implementation of CRUD service for the Ticket entity.
/// </summary>
public sealed class TicketService : CrudService<Ticket>
{
    /// <inheritdoc/>
    protected override Guid GetIdFromEntity(Ticket entity)
        => entity.Id;

    /// <inheritdoc/>
    protected override Ticket CopyEntity(Ticket entity) 
        => new(entity);
}