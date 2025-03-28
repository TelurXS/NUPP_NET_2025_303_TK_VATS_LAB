using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Vehicles.Common.Contracts;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An in-memory implementation of CRUD service for the Train entity.
/// </summary>
public sealed class TrainService : ICrudService<Train>
{
    /// <summary>
    /// A dictionary that stores entities in memory.
    /// </summary>
    private Dictionary<Guid, Train> _storage = new();
    
    /// <inheritdoc/>
    public void Create(Train element)
        => _storage.Add(element.Id, new Train(element));

    /// <inheritdoc/>
    public Train? Read(Guid id) 
        => _storage.GetValueOrDefault(id);

    /// <inheritdoc/>
    public IEnumerable<Train> ReadAll()
        =>  _storage.Values;

    /// <inheritdoc/>
    public void Update(Train element)
    {
        var entity = Read(element.Id);
        
        if  (entity is null)
            return;
        
        _storage[entity.Id] = new Train(element);
    }

    /// <inheritdoc/>
    public void Remove(Train element)
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
            _storage = JsonConvert.DeserializeObject<Dictionary<Guid, Train>>(json)!;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}