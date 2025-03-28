using System.Diagnostics.CodeAnalysis;

namespace Vehicles.Common.Contracts;

/// <summary>
/// A CRUD interface for storing, creating and manipulating entities of specific type.
/// </summary>
/// <typeparam name="T">Type of entity.</typeparam>
public interface ICrudService<T>
{
    /// <summary>
    /// Saves an <typeparamref name="T"/>.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be saved.</param>
    public void Create(T element);
    
    /// <summary>
    /// Finds a specific <typeparamref name="T"/> by id.
    /// </summary>
    /// <param name="id">A guid id of an <typeparamref name="T"/>. </param>
    /// <returns>Found <typeparamref name="T"/> or null.</returns>
    public T? Read(Guid id);
    
    /// <summary>
    /// Finds all elements of type <typeparamref name="T"/> in storage.
    /// </summary>
    /// <returns>A collection that contains all entries of <typeparamref name="T"/>.</returns>
    public IEnumerable<T> ReadAll();
    
    /// <summary>
    /// Updates specific <typeparamref name="T"/>.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be updated.</param>
    public void Update(T element);
    
    /// <summary>
    /// Removes specific <typeparamref name="T"/> from storage.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be removed.</param>
    public void Remove(T element);
    
    /// <summary>
    /// Saves all current entries in file.
    /// </summary>
    /// <param name="path">The path to file.</param>
    public void Save([StringSyntax(StringSyntaxAttribute.Uri)] string path);
    
    /// <summary>
    /// Loads all entries from file.
    /// </summary>
    /// <param name="path">The path to file.</param>
    public void Load([StringSyntax(StringSyntaxAttribute.Uri)] string path);
}