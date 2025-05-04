using Vehicles.Common.Entities;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An in-memory implementation of CRUD service for the Train entity.
/// </summary>
public sealed class TrainService : CrudService<Train>
{
    /// <inheritdoc/>
    protected override Guid GetIdFromEntity(Train entity)
        => entity.Id;

    /// <inheritdoc/>
    protected override Train CopyEntity(Train entity) 
        => Vehicle.IgnoreCreatedRecording(new Train(entity));
}