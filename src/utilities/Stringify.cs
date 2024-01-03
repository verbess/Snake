namespace Snake.Utilities;

/// <summary>
/// Provides static methods for formatting string by replacing it with the string representation of specified objects.
/// </summary>
public static class Stringify
{
    private static readonly ThreadLocal<IFormatter?> t_formatter;

    /// <summary>
    /// Initializes the static fields of the <see cref="Stringify" /> class.
    /// </summary>
    static Stringify() => t_formatter = new ThreadLocal<IFormatter?>();

    /// <summary>
    /// Sets the formatter for string formatting operations.
    /// </summary>
    /// <param name="formatter">The formatter to set, or <c>null</c> if default behavior is desired.</param>
    public static void SetFormatter(IFormatter? formatter) => t_formatter.Value = formatter;

    /// <summary>
    /// Replaces one or more format items in a string with the string representation of a specified object.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The object to format.</param>
    /// <returns>
    /// A copy of <paramref name="format" /> in which any format items have been replaced by the string representation
    /// of <paramref name="arg0" />.
    /// </returns>
    public static string Format(string format, object? arg0)
    {
        ArgumentNullException.ThrowIfNull(format);

        return t_formatter.Value?.Format(format, arg0) ?? string.Format(format, arg0);
    }

    /// <summary>
    /// Replaces the format items in a string with the string representation of two specified objects.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The first object to format.</param>
    /// <param name="arg1">The second object to format.</param>
    /// <returns>
    /// A copy of <paramref name="format" /> in which the format items have been replaced by the string representations
    /// of <paramref name="arg0" /> and <paramref name="arg1" />.
    /// </returns>
    public static string Format(string format, object? arg0, object? arg1)
    {
        ArgumentNullException.ThrowIfNull(format);

        return t_formatter.Value?.Format(format, arg0, arg1) ?? string.Format(format, arg0, arg1);
    }

    /// <summary>
    /// Replaces the format items in a string with the string representation of three specified objects.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arg0">The first object to format.</param>
    /// <param name="arg1">The second object to format.</param>
    /// <param name="arg2">The third object to format.</param>
    /// <returns>
    /// A copy of <paramref name="format" /> in which the format items have been replaced by the string representations
    /// of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.
    /// </returns>
    public static string Format(string format, object? arg0, object? arg1, object? arg2)
    {
        ArgumentNullException.ThrowIfNull(format);

        return t_formatter.Value?.Format(format, arg0, arg1, arg2) ?? string.Format(format, arg0, arg1, arg2);
    }

    /// <summary>
    /// Replaces the format items in a string with the string representation of a corresponding objects in a specified
    /// array.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An object array that contains zero or more objects to format.</param>
    /// <returns>
    /// A copy of <paramref name="format" /> in which the format items have been replaced by the string representation
    /// of the corresponding objects in <paramref name="args" />.
    /// </returns>
    public static string Format(string format, params object?[] args)
    {
        ArgumentNullException.ThrowIfNull(format);

        return t_formatter.Value?.Format(format, args) ?? string.Format(format, args);
    }

    /// <summary>
    /// Defines methods for formatting string by replacing it with the string representation of specified objects.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Replaces one or more format items in a string with the string representation of a specified object.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <returns>
        /// A copy of <paramref name="format" /> in which any format items have been replaced by the string
        /// representation of <paramref name="arg0" />.
        /// </returns>
        public string Format(string format, object? arg0);

        /// <summary>
        /// Replaces the format items in a string with the string representation of two specified objects.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <returns>
        /// A copy of <paramref name="format" /> in which the format items have been replaced by the string
        /// representations of <paramref name="arg0" /> and <paramref name="arg1" />.
        /// </returns>
        public string Format(string format, object? arg0, object? arg1);

        /// <summary>
        /// Replaces the format items in a string with the string representation of three specified objects.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <param name="arg2">The third object to format.</param>
        /// <returns>
        /// A copy of <paramref name="format" /> in which the format items have been replaced by the string
        /// representations of <paramref name="arg0" />, <paramref name="arg1" />, and <paramref name="arg2" />.
        /// </returns>
        public string Format(string format, object? arg0, object? arg1, object? arg2);

        /// <summary>
        /// Replaces the format items in a string with the string representation of a corresponding objects in a
        /// specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>
        /// A copy of <paramref name="format" /> in which the format items have been replaced by the string
        /// representation of the corresponding objects in <paramref name="args" />.
        /// </returns>
        public string Format(string format, params object?[] args);
    }
}
