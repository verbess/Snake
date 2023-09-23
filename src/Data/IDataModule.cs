using System.Diagnostics.CodeAnalysis;

namespace Snake.Data;

/// <summary>
/// Exposes methods to access the <see cref="DataModule" /> that stores and retrieves data objects.
/// </summary>
public interface IDataModule
{
    /// <summary>
    /// Attempts to get the data associated with the specified key from the <see cref="IDataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to get.</typeparam>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the <see cref="IDataModule" /> that has the specified
    /// key, or the default value of the <typeparamref name="T" /> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the <see cref="DataModule" />; otherwise, <c>false</c>.</returns>
    public bool TryGet<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to get the data associated with the specified key from the <see cref="IDataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to get.</param>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the <see cref="IDataModule" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the <see cref="IDataModule" />; otherwise, <c>false</c>.</returns>
    public bool TryGet(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data);

    /// <summary>
    /// Attempts to add the data to the <see cref="IDataModule" />.
    /// </summary>
    /// <param name="data">The data to add.</param>
    /// <returns>
    /// <c>true</c> if the data was added to the <see cref="IDataModule" /> successfully; <c>false</c> if the data
    /// already exists.
    /// </returns>
    public bool TryAdd(IKeyed data);

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the <see cref="IDataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove.</typeparam>
    /// <returns>
    /// <c>true</c> if the data were removed from the <see cref="IDataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>()
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the <see cref="IDataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove.</param>
    /// <returns>
    /// <c>true</c> if the data were removed from the <see cref="IDataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type dataType);

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the <see cref="IDataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove and return.</typeparam>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the <see cref="IDataModule" /> that has the specified
    /// key, or the default value of the <typeparamref name="T" /> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the <see cref="IDataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed;

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the <see cref="IDataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove and return.</param>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the <see cref="IDataModule" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the <see cref="IDataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data);

    /// <summary>
    /// Removes all keys and data from the <see cref="IDataModule" />.
    /// </summary>
    public void Clear();
}
