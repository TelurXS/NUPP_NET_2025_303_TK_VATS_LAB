using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Vehicles.Common.Contracts;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An abstraction class for CRUD service. Implements <see cref="ICrudService{T}"/> interface.
/// </summary>
public abstract class CrudService<T> : ICrudService<T>
{
    /// <summary>
    /// A dictionary that stores entities in memory.
    /// </summary>
    private Dictionary<Guid, T> _storage = new();
    
    /// <inheritdoc/>
    public void Create(T element)
        => _storage.Add(GetIdFromEntity(element), CopyEntity(element));

    /// <inheritdoc/>
    public T? Read(Guid id) 
        => _storage.GetValueOrDefault(id);

    /// <inheritdoc/>
    public IEnumerable<T> ReadAll()
        =>  _storage.Values;

    /// <inheritdoc/>
    public void Update(T element)
    {
        var entity = Read(GetIdFromEntity(element));
        
        if  (entity is null)
            return;
        
        _storage[GetIdFromEntity(element)] = CopyEntity(element);
    }

    /// <inheritdoc/>
    public void Remove(T element)
        =>  _storage.Remove(GetIdFromEntity(element));

    /// <inheritdoc/>
    public void Save([StringSyntax(StringSyntaxAttribute.Uri)] string path)
    {
        try
        {
            var json = JsonConvert.SerializeObject(_storage);
            File.WriteAllText(path, json);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    /// <inheritdoc/>
    public void Load([StringSyntax(StringSyntaxAttribute.Uri)] string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            _storage = JsonConvert.DeserializeObject<Dictionary<Guid, T>>(json)!;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
    
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