namespace Snake;

/// <summary>
/// Defines a property for data querying.
/// </summary>
public interface IKeyed
{
    /// <summary>
    /// Gets the key of the object.
    /// </summary>
    public string Key { get; }
}
