using System.Collections;
using Vehicles.Common.Contracts;

namespace Vehicles.Infrastructures.Services;

public abstract class DatabaseService<T> : IAsyncCrudService<T>
{
    protected DatabaseService(IRepository<T> repository)
    {
        Repository = repository;
    }
    
    protected IRepository<T> Repository { get; }

    public Task<bool> CreateAsync(T element)
        => Repository.CreateAsync(element);

    public Task<T?> ReadAsync(Guid id)
        => Repository.GetByIdAsync(id);

    public Task<IEnumerable<T>> ReadAllAsync()
        => Repository.GetAllAsync(); 

    public Task<IEnumerable<T>> ReadAllAsync(int count, int page)
        => Repository.GetAllAsync(count, page); 

    public Task<bool> UpdateAsync(T element)
        => Repository.UpdateAsync(element); 

    public Task<bool> RemoveAsync(T element)
        => Repository.DeleteAsync(element);

    public Task<bool> SaveAsync(string path)
        => throw new NotImplementedException();

    public Task<bool> LoadAsync(string path)
        => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
        => Repository.GetAllAsync().Result.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}