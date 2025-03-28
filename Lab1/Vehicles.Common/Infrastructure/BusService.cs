using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Vehicles.Common.Contracts;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An in-memory implementation of CRUD service for the Bus entity.
/// </summary>
public class BusService : ICrudService<Bus>
{
    /// <summary>
    /// A dictionary that stores entities in memory.
    /// </summary>
    private Dictionary<Guid, Bus> _storage = new();
    
    /// <inheritdoc/>
    public void Create(Bus element)
        => _storage.Add(element.Id, new Bus(element));

    /// <inheritdoc/>
    public Bus? Read(Guid id) 
        => _storage.GetValueOrDefault(id);

    /// <inheritdoc/>
    public IEnumerable<Bus> ReadAll()
        =>  _storage.Values;

    /// <inheritdoc/>
    public void Update(Bus element)
    {
        var entity = Read(element.Id);
        
        if  (entity is null)
            return;
        
        _storage[entity.Id] = new Bus(element);
    }

    /// <inheritdoc/>
    public void Remove(Bus element)
        =>  _storage.Remove(element.Id);

    /// <inheritdoc/>
    public void Save([StringSyntax(StringSyntaxAttribute.Uri)] string path)
    {
        var json = JsonConvert.SerializeObject(_storage);
        File.WriteAllText(path, json);
    }

    /// <inheritdoc/>
    public void Load([StringSyntax(StringSyntaxAttribute.Uri)] string path)
    {
        try
        {
            var json = File.ReadAllText(path);
            _storage = JsonConvert.DeserializeObject<Dictionary<Guid, Bus>>(json)!;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}