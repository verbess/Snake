using System.Diagnostics.CodeAnalysis;

namespace Snake.Data;

/// <summary>
/// Defines methods to access a data module that stores and retrieves data objects.
/// </summary>
public interface IDataModule
{
    /// <summary>
    /// Attempts to get the data associated with the specified key from the data module.
    /// </summary>
    /// <typeparam name="T">The type of the data to get.</typeparam>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the data module that has the specified key, or the
    /// default value of the <typeparamref name="T"/> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the data module; otherwise, <c>false</c>.</returns>
    public bool TryGetData<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to get the data associated with the specified key from the data module.
    /// </summary>
    /// <param name="type">The type of the data to get.</param>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the data module that has the specified key, or the
    /// default value of the <see cref="IKeyed"/> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the data module; otherwise, <c>false</c>.</returns>
    public bool TryGetData(Type type, string key, [MaybeNullWhen(false)] out IKeyed data);

    /// <summary>
    /// Attempts to add data to the data module.
    /// </summary>
    /// <param name="data">The data to add.</param>
    /// <returns><c>true</c> if the data was added to the data module successfully; otherwise, <c>false</c>.</returns>
    public bool TryAdd(IKeyed data);

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the data module.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove.</typeparam>
    /// <returns>
    /// <c>true</c> if the data were removed from the data module successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>()
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the data module.
    /// </summary>
    /// <param name="type">The type of the data to remove.</param>
    /// <returns>
    /// <c>true</c> if the data were removed from the data module successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type type);

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the data module.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove and return.</typeparam>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the data module that has the specified key, or the
    /// default value of the <typeparamref name="T"/> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the data module successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the data module.
    /// </summary>
    /// <param name="type">The type of the data to remove and return.</param>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the data module that has the specified key, or the
    /// default value of the <see cref="IKeyed"/> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the data module successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type type, string key, [MaybeNullWhen(false)] out IKeyed data);

    /// <summary>
    /// Clears all keys and data from the data module.
    /// </summary>
    public void Clear();
}
