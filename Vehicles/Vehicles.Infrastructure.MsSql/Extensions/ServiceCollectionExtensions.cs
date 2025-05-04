using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Infrastructure.MsSql.DataContexts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.DataContexts;
using Vehicles.Infrastructures.Services;

namespace Vehicles.Infrastructure.MsSql.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlServerDataContext(this IServiceCollection services)
    {
        services.AddDbContext<IDataContext, VehiclesDataContext>(x =>
            // I was too lazy to hide the connstring so that's it :3
            x.UseSqlServer(
                    "Server=DESKTOP-DKNJB6I\\SQLEXPRESS;Database=vehiclesdb;User Id=DESKTOP-DKNJB6I\\User;Password=;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false;")
                .UseAsyncSeeding(DatabaseSeeder.Seed)
        );
        
        return services;
    }
}