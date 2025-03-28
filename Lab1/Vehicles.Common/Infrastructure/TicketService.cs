using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Vehicles.Common.Contracts;

namespace Vehicles.Common.Infrastructure;

/// <summary>
/// An in-memory implementation of CRUD service for the Ticket entity.
/// </summary>
public sealed class TicketService : ICrudService<Ticket>
{
    /// <summary>
    /// A dictionary that stores entities in memory.
    /// </summary>
    private Dictionary<Guid, Ticket> _storage = new();
    
    /// <inheritdoc/>
    public void Create(Ticket element)
        => _storage.Add(element.Id, new Ticket(element));

    /// <inheritdoc/>
    public Ticket? Read(Guid id) 
        => _storage.GetValueOrDefault(id);

    /// <inheritdoc/>
    public IEnumerable<Ticket> ReadAll()
        =>  _storage.Values;

    /// <inheritdoc/>
    public void Update(Ticket element)
    {
        var entity = Read(element.Id);
        
        if  (entity is null)
            return;
        
        _storage[entity.Id] = new Ticket(element);
    }

    /// <inheritdoc/>
    public void Remove(Ticket element)
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
            _storage = JsonConvert.DeserializeObject<Dictionary<Guid, Ticket>>(json)!;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}