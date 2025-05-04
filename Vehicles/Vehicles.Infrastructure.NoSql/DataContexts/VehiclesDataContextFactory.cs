using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Infrastructure.NoSql.Extensions;
using Vehicles.Infrastructures.Contracts;

namespace Vehicles.Infrastructure.NoSql.DataContexts;

public sealed class VehiclesDataContextFactory : IDesignTimeDbContextFactory<VehiclesDataContext>
{
    public VehiclesDataContext CreateDbContext(string[] args)
    {
        return (VehiclesDataContext)
            new ServiceCollection()
            .AddMongoDbDataContext()
            .BuildServiceProvider()
            .GetRequiredService<IDataContext>();
    }
}