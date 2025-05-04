using Vehicles.Common.Entities;

namespace Vehicles.Common.Infrastructure.Async;

/// <summary>
/// An async in-memory implementation of CRUD service for the Ticket entity.
/// </summary>
public sealed class AsyncTicketService : AsyncCrudService<Ticket>
{
    /// <inheritdoc/>
    protected override Guid GetIdFromEntity(Ticket entity)
        => entity.Id;

    /// <inheritdoc/>
    protected override Ticket CopyEntity(Ticket entity) 
        => new Ticket(entity);
}