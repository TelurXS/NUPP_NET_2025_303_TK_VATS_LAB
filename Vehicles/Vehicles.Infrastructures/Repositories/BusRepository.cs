using Microsoft.EntityFrameworkCore;
using Vehicles.Common.Contracts;
using Vehicles.Infrastructures.Contracts;
using Vehicles.Infrastructures.Models;

namespace Vehicles.Infrastructures.Repositories;

public sealed class BusRepository : IRepository<BusModel>
{
    public BusRepository(IDataContext dataContext)
    {
        DataContext = dataContext;
        Entries = dataContext.Busses;
    }

    private IDataContext DataContext { get; }
    private DbSet<BusModel> Entries { get; }

    public async Task<bool> CreateAsync(BusModel element)
    {
        await Entries.AddAsync(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<BusModel?> GetByIdAsync(Guid id)
    {
        return await Entries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<BusModel>> GetAllAsync()
    {
        return await Entries.ToListAsync();
    }

    public async Task<IEnumerable<BusModel>> GetAllAsync(int count, int page)
    {
        return await Entries
                .Skip(page * count)
                .Take(count)
                .ToListAsync();
    }

    public async Task<bool> UpdateAsync(BusModel element)
    {
        Entries.Update(element);
        return await DataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(BusModel element)
    {
        Entries.Remove(element);
        return await DataContext.SaveChangesAsync() > 0;
    }
}