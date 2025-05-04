using Microsoft.EntityFrameworkCore;
using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Repositories;

public sealed class TrainRouteRepository : IRepository<TrainRouteModel>
{
    public TrainRouteRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
        Entries = dataContext.TrainRoutes;
    }

    private IDataContext DataContext { get; }
    private DbSet<TrainRouteModel> Entries { get; }

    public async Task<bool> CreateAsync(TrainRouteModel element)
    {
        await Entries.AddAsync(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<TrainRouteModel?> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TrainRouteModel>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }

    public async Task<IEnumerable<TrainRouteModel>> GetAllAsync(int count, int page)
    {
        return await Entries
            .Skip(page * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(TrainRouteModel element)
    {
        Entries.Update(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(TrainRouteModel element)
    {
        Entries.Remove(element);
        return await DataContext.SaveChangesAsync() > 0;
    }
}