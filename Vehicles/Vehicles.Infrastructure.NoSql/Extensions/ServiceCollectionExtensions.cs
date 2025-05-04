using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Infrastructure.NoSql.DataContexts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Services;

namespace Vehicles.Infrastructure.NoSql.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDbDataContext(this IServiceCollection services)
    {
        services.AddDbContext<IDataContext, VehiclesDataContext>(x =>
            // Suffering O' Suffering
            x.UseMongoDB("mongodb+srv://user:0Password1@cluster0.f5yj0m3.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0", 
                    "vehicles")
                .UseAsyncSeeding(DatabaseSeeder.Seed)
        );
        
        return services;
    }
}