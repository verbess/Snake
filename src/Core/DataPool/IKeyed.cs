namespace Snake;

/// <summary>
/// Provides a basic <see cref="Key" /> property for data querying.
/// </summary>
public interface IKeyed
{
    /// <summary>
    /// Gets the key of the <see cref="IKeyed" />.
    /// </summary>
    public string Key { get; }
}
