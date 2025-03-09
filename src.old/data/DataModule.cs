using System.Diagnostics.CodeAnalysis;

namespace Snake.Data;

/// <summary>
/// Represents a data module that stores and retrieves data objects.
/// </summary>
internal sealed class DataModule : Module, IDataModule
{
    private readonly DataPool _pool;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataModule" /> class.
    /// </summary>
    internal DataModule()
        : base() => _pool = new DataPool();

    /// <summary>
    /// Shuts down the module and releases any resources held by it.
    /// </summary>
    internal override void Shutdown() => Clear();

    /// <summary>
    /// Attempts to get the data associated with the specified key from the <see cref="DataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to get.</typeparam>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the <see cref="DataModule" /> that has the specified
    /// key, or the default value of the <typeparamref name="T" /> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the <see cref="DataModule" />; otherwise, <c>false</c>.</returns>
    public bool TryGetData<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed
    {
        _ = TryGetData(typeof(T), key, out IKeyed? temp);
        data = temp as T;

        return data is not null;
    }

    /// <summary>
    /// Attempts to get the data associated with the specified key from the <see cref="DataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to get.</param>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the <see cref="DataModule" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the <see cref="DataModule" />; otherwise, <c>false</c>.</returns>
    public bool TryGetData(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(dataType);
        ArgumentNullException.ThrowIfNull(key);

        return _pool.TryGetData(dataType, key, out data);
    }

    /// <summary>
    /// Attempts to add a data to the <see cref="DataModule" />.
    /// </summary>
    /// <param name="data">The data to add.</param>
    /// <returns>
    /// <c>true</c> if the data was added to the <see cref="DataModule" /> successfully; <c>false</c> if the data
    /// already exists.
    /// </returns>
    public bool TryAdd(IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(data);

        return _pool.TryAdd(data);
    }

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the <see cref="DataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove.</typeparam>
    /// <returns>
    /// <c>true</c> if the data were removed from the <see cref="DataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>()
        where T : class, IKeyed => TryRemove(typeof(T));

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the <see cref="DataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove.</param>
    /// <returns>
    /// <c>true</c> if the data were removed from the <see cref="DataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type dataType)
    {
        ArgumentNullException.ThrowIfNull(dataType);

        return _pool.TryRemove(dataType);
    }

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the <see cref="DataModule" />.
    /// </summary>
    /// <typeparam name="T">The type of the data to remove and return.</typeparam>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the <see cref="DataModule" /> that has the specified
    /// key, or the default value of the <typeparamref name="T" /> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the <see cref="DataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed
    {
        _ = TryRemove(typeof(T), key, out IKeyed? temp);
        data = temp as T;

        return data is not null;
    }

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the <see cref="DataModule" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove and return.</param>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the <see cref="DataModule" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the <see cref="DataModule" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    public bool TryRemove(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(dataType);
        ArgumentNullException.ThrowIfNull(key);

        return _pool.TryRemove(dataType, key, out data);
    }

    /// <summary>
    /// Clears all keys and data from the <see cref="DataModule" />.
    /// </summary>
    public void Clear() => _pool.Clear();
}
