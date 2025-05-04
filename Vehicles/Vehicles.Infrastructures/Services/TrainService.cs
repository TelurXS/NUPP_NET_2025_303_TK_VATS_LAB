using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

public sealed class TrainService : DatabaseService<TrainModel>
{
    public TrainService(IRepository<TrainModel> repository) : base(repository)
    {
    }
}