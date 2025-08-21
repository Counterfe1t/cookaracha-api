using Cookaracha.Core.Entities;
using Cookaracha.Core.ValueObjects;

namespace Cookaracha.Core.Repositories;

public interface IUsersRepository
{
    /// <summary>
    /// Get user by ID.
    /// </summary>
    /// <param name="id">Unique user identifier.</param>
    /// <returns><see cref="User" /> entity model or null if none was found.</returns>
    Task<User?> GetAsync(EntityId id);

    /// <summary>
    /// Get user by email address.
    /// </summary>
    /// <param name="email">Unique user email address.</param>
    /// <returns><see cref="User" /> entity model or null if none was found.</returns>
    Task<User?> GetAsync(Email email);

    /// <summary>
    /// Get user by user name.
    /// </summary>
    /// <param name="name">Unique user name.</param>
    /// <returns><see cref="User" /> entity model or null if none was found.</returns>
    Task<User?> GetAsync(UserName name);

    /// <summary>
    /// Add user.
    /// </summary>
    /// <param name="user"><see cref="User"/> entity model.</param>
    Task AddAsync(User user);

    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="user"><see cref="User"/> entity model.</param>
    Task UpdateAsync(User user);

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <param name="user"><see cref="User"/> entity model.</param>
    Task DeleteAsync(User user);
}