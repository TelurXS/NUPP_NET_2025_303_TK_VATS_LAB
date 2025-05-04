using System.Diagnostics.CodeAnalysis;

namespace Vehicles.Common.Contracts;

/// <summary>
/// An asynchronous CRUD interface for storing, creating and manipulating entities of specific type.
/// </summary>
/// <typeparam name="T">Type of entity.</typeparam>
public interface IAsyncCrudService<T> : IEnumerable<T>
{
    /// <summary>
    /// Saves the <typeparamref name="T"/> asynchronously.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be saved.</param>
    public Task<bool> CreateAsync(T element);
    
    /// <summary>
    /// Finds a specific <typeparamref name="T"/> by id asynchronously.
    /// </summary>
    /// <param name="id">A guid id of an <typeparamref name="T"/>. </param>
    /// <returns>Found <typeparamref name="T"/> or null.</returns>
    public Task<T?> ReadAsync(Guid id);
    
    /// <summary>
    /// Finds all elements of type <typeparamref name="T"/> in storage asynchronously.
    /// </summary>
    /// <returns>A collection that contains all entries of <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> ReadAllAsync();
    
    /// <summary>
    /// Finds all elements of type <typeparamref name="T"/> in storage asynchronously.
    /// Supports pagination.
    /// </summary>
    /// <param name="count">Count of entities per page.</param>
    /// <param name="page">Page from which to find.</param>
    /// <returns>A collection that contains all entries of <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> ReadAllAsync(int count, int page);
    
    /// <summary>
    /// Updates specific <typeparamref name="T"/> asynchronously.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be updated.</param>
    public Task<bool> UpdateAsync(T element);
    
    /// <summary>
    /// Removes specific <typeparamref name="T"/> from storage asynchronously.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be removed.</param>
    public Task<bool> RemoveAsync(T element);
    
    /// <summary>
    /// Saves all current entries in file asynchronously.
    /// </summary>
    /// <param name="path">The path to file.</param>
    public Task<bool> SaveAsync([StringSyntax(StringSyntaxAttribute.Uri)] string path);
    
    /// <summary>
    /// Loads all entries from file asynchronously.
    /// </summary>
    /// <param name="path">The path to file.</param>
    public Task<bool> LoadAsync([StringSyntax(StringSyntaxAttribute.Uri)] string path);
}