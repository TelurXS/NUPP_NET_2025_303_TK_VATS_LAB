using Microsoft.EntityFrameworkCore;
using Vehicles.Infrastructures;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructure.MsSql.DataContexts;

public sealed class VehiclesDataContext : DbContext, IDataContext
{
    public VehiclesDataContext(DbContextOptions<VehiclesDataContext> options) : base(options)
    {
    }
    
    public DbSet<TrainModel> Trains { get; set; }
    public DbSet<TrainRouteModel> TrainRoutes { get; set; }
    public DbSet<BusModel> Busses { get; set; }
    public DbSet<TicketModel> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(IAssemblyMark.Assembly);
    }
}