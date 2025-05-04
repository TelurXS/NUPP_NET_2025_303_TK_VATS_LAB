using Riok.Mapperly.Abstractions;
using Vehicles.Common.Entities;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

[Mapper(PreferParameterlessConstructors = false)]
public sealed partial class EntityMapper : IEntityMapper
{
    [MapperIgnoreTarget(nameof(TrainModel.Routes))]
    [MapperIgnoreTarget(nameof(TrainModel.Tickets))]
    public partial TrainModel ToModel(Train train);

    [MapperIgnoreTarget(nameof(TrainRouteModel.Trains))]
    public partial TrainRouteModel ToModel(TrainRoute route);

    public partial TicketModel ToModel(Ticket ticket, Train train);

    public partial BusModel ToModel(Bus bus);
    
    [MapperIgnoreSource(nameof(TrainModel.Routes))]
    [MapperIgnoreSource(nameof(TrainModel.Tickets))]
    public partial Train FromModel(TrainModel model);

    [MapperIgnoreSource(nameof(TrainRouteModel.Trains))]
    public partial TrainRoute FromModel(TrainRouteModel model);

    [MapperIgnoreSource(nameof(TicketModel.Train))]
    public partial Ticket FromModel(TicketModel model);
    
    public partial Bus FromModel(BusModel model);
}