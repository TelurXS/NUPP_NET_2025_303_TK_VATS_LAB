using System.Diagnostics.CodeAnalysis;

namespace Vehicles.Common.Contracts;

/// <summary>
/// Repository interface for working with database entity of specific type.
/// </summary>
/// <typeparam name="T">Type of entity.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Creates the <typeparamref name="T"/>.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be saved.</param>
    public Task<bool> CreateAsync(T element);
    
    /// <summary>
    /// Finds a specific <typeparamref name="T"/> by id.
    /// </summary>
    /// <param name="id">A guid id of an <typeparamref name="T"/>. </param>
    /// <returns>Found <typeparamref name="T"/> or null.</returns>
    public Task<T?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Finds all elements of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>A collection that contains all entries of <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> GetAllAsync();
    
    /// <summary>
    /// Finds all elements of type <typeparamref name="T"/> with pagination.
    /// </summary>
    /// <param name="count">Count of entities per page.</param>
    /// <param name="page">Page from which to find.</param>
    /// <returns>A collection that contains all entries of <typeparamref name="T"/>.</returns>
    public Task<IEnumerable<T>> GetAllAsync(int count, int page);
    
    /// <summary>
    /// Updates specific <typeparamref name="T"/>.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be updated.</param>
    public Task<bool> UpdateAsync(T element);
    
    /// <summary>
    /// Deletes specific <typeparamref name="T"/>.
    /// </summary>
    /// <param name="element">The <typeparamref name="T"/> to be removed.</param>
    public Task<bool> DeleteAsync(T element);
}