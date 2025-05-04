using Riok.Mapperly.Abstractions;
using Vehicles.Common.Entities;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Contracts;

public interface IEntityMapper
{
    public TrainModel ToModel(Train train);

    public TrainRouteModel ToModel(TrainRoute route);

    public TicketModel ToModel(Ticket ticket, Train train);

    public BusModel ToModel(Bus bus);

    public Train FromModel(TrainModel model);

    public TrainRoute FromModel(TrainRouteModel model);

    public Ticket FromModel(TicketModel model);
    
    public Bus FromModel(BusModel model);
}