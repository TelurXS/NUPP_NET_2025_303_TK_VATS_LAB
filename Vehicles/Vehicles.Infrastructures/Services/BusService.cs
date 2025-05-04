using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

public sealed class BusService : DatabaseService<BusModel>
{
    public BusService(IRepository<BusModel> repository) : base(repository)
    {
    }
}