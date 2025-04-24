using System.Collections;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using Vehicles.Common.Contracts;

namespace Vehicles.Common.Infrastructure.Async;

public abstract class AsyncCrudService<T> : IAsyncCrudService<T>
{
    /// <summary>
    /// A concurrent dictionary that stores entities in memory.
    /// </summary>
    private ConcurrentDictionary<Guid, T> _storage = new();
    
    /// <summary>
    /// A semaphore slim that ensures thread safety.
    /// </summary>
    private readonly SemaphoreSlim _lock = new(1, 1);
    
    /// <inheritdoc/>
    public Task<bool> CreateAsync(T element) 
        => Task.FromResult(_storage.TryAdd(
            GetIdFromEntity(element), 
            CopyEntity(element)));

    /// <inheritdoc/>
    public Task<T?> ReadAsync(Guid id)
    {
        Task.FromResult(_storage.TryGetValue(id, out var value));
        return Task.FromResult(value);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<T>> ReadAllAsync()
    {
        return Task.FromResult(_storage.Values.AsEnumerable());
    }

    /// <inheritdoc/>
    public Task<IEnumerable<T>> ReadAllAsync(int count, int page)
    {
        var result = _storage
            .Values
            .AsEnumerable()
            .Skip(page * count)
            .Take(count);
        
        return Task.FromResult(result);
    }

    /// <inheritdoc/>
    public Task<bool> UpdateAsync(T element)
    {
        if (_storage.ContainsKey(GetIdFromEntity(element)) is false)
            return Task.FromResult(false);
        
        _storage[GetIdFromEntity(element)] = CopyEntity(element);
        return Task.FromResult(true);
    }

    /// <inheritdoc/>
    public Task<bool> RemoveAsync(T element) 
        => Task.FromResult(_storage.Remove(GetIdFromEntity(element), out _));

    /// <inheritdoc/>
    public async Task<bool> SaveAsync(string path)
    {
        try
        {
            await _lock.WaitAsync();
            var json = JsonConvert.SerializeObject(_storage);
            await File.WriteAllTextAsync(path, json);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            _lock.Release();
        }
    }

    /// <inheritdoc/>
    public async Task<bool> LoadAsync(string path)
    {
        try
        {
            await _lock.WaitAsync();
            var json = await File.ReadAllTextAsync(path);
            _storage = JsonConvert.DeserializeObject<ConcurrentDictionary<Guid, T>>(json)!;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        finally
        {
            _lock.Release();
        }
    }

    public IEnumerator<T> GetEnumerator() => _storage.Values.GetEnumerator(); 

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    /// <summary>
    /// Gets the id from the entity.
    /// </summary>
    /// <param name="entity">The <typeparamref name="T"/> to get id from.</param>
    /// <returns>The id of the <typeparamref name="T"/>.</returns>
    protected abstract Guid GetIdFromEntity(T entity);
    
    /// <summary>
    /// Copies current state of an entity.
    /// </summary>
    /// <param name="entity">The <typeparamref name="T"/>  to copy.</param>
    /// <returns>A copy of the <typeparamref name="T"/>.</returns>
    protected abstract T CopyEntity(T entity);
}