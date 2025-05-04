using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Services;

public sealed class TicketService : DatabaseService<TicketModel>
{
    public TicketService(IRepository<TicketModel> repository) : base(repository)
    {
    }
}