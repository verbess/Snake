namespace Snake;

/// <summary>
/// Defines a method for data querying.
/// </summary>
public interface IKeyed
{
    /// <summary>
    /// Gets the key of the <see cref="IKeyed" />.
    /// </summary>
    public string Key { get; }
}
