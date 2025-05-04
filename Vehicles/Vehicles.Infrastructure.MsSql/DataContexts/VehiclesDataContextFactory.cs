using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Vehicles.Infrastructure.MsSql.Extensions;
using Vehicles.Infrastructures.Contracts;

namespace Vehicles.Infrastructure.MsSql.DataContexts;

public sealed class VehiclesDataContextFactory : IDesignTimeDbContextFactory<VehiclesDataContext>
{
    public VehiclesDataContext CreateDbContext(string[] args)
    {
        return (VehiclesDataContext)
            new ServiceCollection()
            .AddSqlServerDataContext()
            .BuildServiceProvider()
            .GetRequiredService<IDataContext>();
    }
}