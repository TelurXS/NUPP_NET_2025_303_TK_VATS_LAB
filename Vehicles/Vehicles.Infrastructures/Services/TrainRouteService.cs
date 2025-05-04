using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

public sealed class TrainRouteService : DatabaseService<TrainRouteModel>
{
    public TrainRouteService(IRepository<TrainRouteModel> repository) : base(repository)
    {
    }
}