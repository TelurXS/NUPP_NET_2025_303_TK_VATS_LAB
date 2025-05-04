using Microsoft.Extensions.DependencyInjection;
using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;
using Vehicles.Infrastructures.Repositories;
using Vehicles.Infrastructures.Services;

namespace Vehicles.Infrastructures.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IRepository<TrainModel>, TrainRepository>();
        services.AddTransient<IRepository<TrainRouteModel>, TrainRouteRepository>();
        services.AddTransient<IRepository<TicketModel>, TicketRepository>();
        services.AddTransient<IRepository<BusModel>, BusRepository>();
        
        services.AddTransient<IAsyncCrudService<TrainModel>, TrainService>();
        services.AddTransient<IAsyncCrudService<TrainRouteModel>, TrainRouteService>();
        services.AddTransient<IAsyncCrudService<TicketModel>, TicketService>();
        services.AddTransient<IAsyncCrudService<BusModel>, BusService>();
        
        services.AddTransient<IEntityMapper, EntityMapper>();
        
        return services;
    }
}