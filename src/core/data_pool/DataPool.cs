using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Snake;

/// <summary>
/// Represents a thread-safe data pool that functions as a collection of keys and data.
/// </summary>
internal sealed class DataPool
{
    private readonly ConcurrentDictionary<Type, DataContainer> _containers;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataPool" /> class.
    /// </summary>
    internal DataPool() => _containers = [];

    /// <summary>
    /// Attempts to get the data associated with the specified key from the <see cref="DataPool" />.
    /// </summary>
    /// <param name="dataType">The type of the data to get.</param>
    /// <param name="key">The key of the data to get.</param>
    /// <param name="data">
    /// When this method returns, contains the data obtained from the <see cref="DataPool" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns><c>true</c> if the key was found in the <see cref="DataPool" />; otherwise, <c>false</c>.</returns>
    internal bool TryGetData(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(dataType);
        ArgumentNullException.ThrowIfNull(key);

        data = default;
        _ = _containers.TryGetValue(dataType, out DataContainer? container);

        return container?.TryGetData(key, out data) ?? false;
    }

    /// <summary>
    /// Attempts to add the data to the <see cref="DataPool" />.
    /// </summary>
    /// <param name="data">The data to add.</param>
    /// <returns>
    /// <c>true</c> if the data was added to the <see cref="DataPool" /> successfully; <c>false</c> if the data already
    /// exists.
    /// </returns>
    internal bool TryAdd(IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(data);

        return _containers.GetOrAdd(data.GetType(), _ => new DataContainer()).TryAdd(data);
    }

    /// <summary>
    /// Attempts to remove a series of data that has the specified type from the <see cref="DataPool" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove.</param>
    /// <returns>
    /// <c>true</c> if the data were removed from the <see cref="DataPool" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryRemove(Type dataType)
    {
        ArgumentNullException.ThrowIfNull(dataType);

        return _containers.TryRemove(dataType, out _);
    }

    /// <summary>
    /// Attempts to remove and return the data that has the specified key from the <see cref="DataPool" />.
    /// </summary>
    /// <param name="dataType">The type of the data to remove and return.</param>
    /// <param name="key">The key of the data to remove and return.</param>
    /// <param name="data">
    /// When this method returns, contains the data removed from the <see cref="DataPool" /> that has the specified
    /// key, or the default value of the <see cref="IKeyed" /> if the operation failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the data was removed from the <see cref="DataPool" /> successfully; otherwise, <c>false</c>.
    /// </returns>
    internal bool TryRemove(Type dataType, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(dataType);
        ArgumentNullException.ThrowIfNull(key);

        data = default;
        _ = _containers.TryGetValue(dataType, out DataContainer? container);

        return container?.TryRemove(key, out data) ?? false;
    }

    /// <summary>
    /// Clears all keys and data from the <see cref="DataPool" />.
    /// </summary>
    internal void Clear() => _containers.Clear();

    /// <summary>
    /// Represents a container of key/data pairs.
    /// </summary>
    private sealed class DataContainer
    {
        private readonly Dictionary<string, IKeyed> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContainer" /> class.
        /// </summary>
        internal DataContainer() => _data = [];

        /// <summary>
        /// Attempts to get the data associated with the specified key from the <see cref="DataContainer" />.
        /// </summary>
        /// <param name="key">The key of the data to get.</param>
        /// <param name="data">
        /// When this method returns, contains the data obtained from the <see cref="DataContainer" /> that has the
        /// specified key, or the default value of the <see cref="IKeyed" /> if the operation failed.
        /// </param>
        /// <returns>
        /// <c>true</c> if the key was found in the <see cref="DataContainer" />; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryGetData(string key, [MaybeNullWhen(false)] out IKeyed data) =>
            _data.TryGetValue(key, out data);

        /// <summary>
        /// Attempts to add the data to the <see cref="DataContainer" />.
        /// </summary>
        /// <param name="data">The data to add.</param>
        /// <returns>
        /// <c>true</c> if the data was added to the <see cref="DataContainer" /> successfully; <c>false</c> if the
        /// data already exists.
        /// </returns>
        internal bool TryAdd(IKeyed data) => _data.TryAdd(data.Key, data);

        /// <summary>
        /// Attempts to remove and return the data that has the specified key from the <see cref="DataContainer" />.
        /// </summary>
        /// <param name="key">The key of the data to remove and return.</param>
        /// <param name="data">
        /// When this method returns, contains the data removed from the <see cref="DataContainer" /> that has the
        /// specified key, or the default value of the <see cref="IKeyed" /> if the operation failed.
        /// </param>
        /// <returns>
        /// <c>true</c> if the data was removed from the <see cref="DataContainer" /> successfully; otherwise,
        /// <c>false</c>.
        /// </returns>
        internal bool TryRemove(string key, [MaybeNullWhen(false)] out IKeyed data) => _data.Remove(key, out data);
    }
}
