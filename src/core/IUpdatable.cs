namespace Snake;

/// <summary>
/// Defines a method that updates a updatable <see cref="Module" />.
/// </summary>
internal interface IUpdatable
{
    /// <summary>
    /// Updates the module with the specified elapsed time.
    /// </summary>
    /// <param name="logicalElapse">The logical elapsed time in seconds.</param>
    /// <param name="realElapse">The real elapsed time in seconds.</param>
    internal void Update(double logicalElapse, double realElapse);
}
