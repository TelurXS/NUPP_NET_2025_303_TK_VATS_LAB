using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Contracts;

public interface IDataContext
{
    public DbSet<TrainModel> Trains { get; set; }
    public DbSet<TrainRouteModel> TrainRoutes { get; set; }
    public DbSet<BusModel> Busses { get; set; }
    public DbSet<TicketModel> Tickets { get; set; }
    
    public DatabaseFacade Database { get; }
    
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}