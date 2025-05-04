using Vehicles.Common.Entities;

namespace Vehicles.Common.Infrastructure.Async;

/// <summary>
/// An async in-memory implementation of CRUD service for the Bus entity.
/// </summary>
public sealed class AsyncBusService : AsyncCrudService<Bus>
{
    /// <inheritdoc/>
    protected override Guid GetIdFromEntity(Bus entity)
        => entity.Id;

    /// <inheritdoc/>
    protected override Bus CopyEntity(Bus entity) 
        => Vehicle.IgnoreCreatedRecording(new Bus(entity));
}