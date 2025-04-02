using System.Diagnostics.CodeAnalysis;

namespace Snake.Data;

/// <summary>
/// Represents a data module that stores and retrieves data objects.
/// </summary>
public sealed class DataModule : IDataModule
{
    private readonly DataPool _pool = new();

    /// <inheritdoc />
    public bool TryGetData<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed
    {
        _ = TryGetData(typeof(T), key, out IKeyed? temp);
        data = temp as T;

        return data is not null;
    }

    /// <inheritdoc />
    public bool TryGetData(Type type, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(key);

        return _pool.TryGetData(type, key, out data);
    }

    /// <inheritdoc />
    public bool TryAdd(IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(data);

        return _pool.TryAdd(data);
    }

    /// <inheritdoc />
    public bool TryRemove<T>()
        where T : class, IKeyed => TryRemove(typeof(T));

    /// <inheritdoc />
    public bool TryRemove(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        return _pool.TryRemove(type);
    }

    /// <inheritdoc />
    public bool TryRemove<T>(string key, [MaybeNullWhen(false)] out T data)
        where T : class, IKeyed
    {
        _ = TryRemove(typeof(T), key, out IKeyed? temp);
        data = temp as T;

        return data is not null;
    }

    /// <inheritdoc />
    public bool TryRemove(Type type, string key, [MaybeNullWhen(false)] out IKeyed data)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(key);

        return _pool.TryRemove(type, key, out data);
    }

    /// <inheritdoc />
    public void Clear() => _pool.Clear();
}
