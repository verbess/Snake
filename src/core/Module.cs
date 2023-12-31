namespace Snake;

/// <summary>
/// Represents the base class for all modules in the <see cref="Snake" /> framework.
/// </summary>
internal abstract class Module
{
    /// <summary>
    /// Defines the default priority value of a module, which is "0".
    /// </summary>
    internal const int DefaultPriority = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="Module" /> class.
    /// </summary>
    private protected Module() { }

    /// <summary>
    /// Gets the priority of the module, which defaults to <see cref="DefaultPriority" />.
    /// </summary>
    /// <remarks>Modules with higher priority will be updated earlier and shut down later.</remarks>
    internal virtual int Priority => DefaultPriority;

    /// <summary>
    /// Shuts down the module and releases any resources held by it.
    /// </summary>
    internal abstract void Shutdown();
}
