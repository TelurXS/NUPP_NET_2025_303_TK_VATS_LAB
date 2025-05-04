using Microsoft.EntityFrameworkCore;
using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Repositories;

public sealed class TrainRepository : IRepository<TrainModel>
{
    public TrainRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
        Entries = dataContext.Trains;
    }

    private IDataContext DataContext { get; }
    private DbSet<TrainModel> Entries { get; }

    public async Task<bool> CreateAsync(TrainModel element)
    {
        await DataContext.Trains.AddAsync(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<TrainModel?> GetByIdAsync(Guid id)
    {
        return await DataContext.Trains.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TrainModel>> GetAllAsync()
    {
        return await DataContext.Trains.ToListAsync();
    }

    public async Task<IEnumerable<TrainModel>> GetAllAsync(int count, int page)
    {
        return await DataContext.Trains
            .Skip(page * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(TrainModel element)
    {
        DataContext.Trains.Update(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(TrainModel element)
    {
        DataContext.Trains.Remove(element);
        return await DataContext.SaveChangesAsync() > 0;
    }
}