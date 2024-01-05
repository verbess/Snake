namespace Snake;

/// <summary>
/// Serves as the resource class for exception error message constants.
/// </summary>
internal static class Messages
{
    #region Argument exceptions
    /// <summary>
    /// Type passed must be an interface.
    /// </summary>
    internal const string Argument_MustBeInterface = @"Type passed must be an interface.";
    #endregion

    #region Snake exceptions
    /// <summary>
    /// Snake framework error.
    /// </summary>
    internal const string Snake_Exception = @"Snake framework error.";

    /// <summary>
    /// Module '{0}' creation failed.
    /// </summary>
    internal const string Snake_ModuleCreationFailed = @"Module '{0}' creation failed.";

    /// <summary>
    /// Module '{0}' was not found.
    /// </summary>
    internal const string Snake_ModuleNotFound = @"Module '{0}' was not found.";

    /// <summary>
    /// Type '{0}' is not a standard Snake module.
    /// </summary>
    internal const string Snake_NotStandardModule = @"Type '{0}' is not a standard Snake module.";
    #endregion
}
