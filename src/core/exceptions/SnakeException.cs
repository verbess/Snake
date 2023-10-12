using System.Runtime.Serialization;

namespace Snake;

/// <summary>
/// Serves as the base class for Snake exceptions namespace.
/// </summary>
[Serializable]
public class SnakeException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnakeException" /> class.
    /// </summary>
    public SnakeException()
        : base(Messages.Snake_Exception) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnakeException" /> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SnakeException(string? message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnakeException" /> class with a specified error message and a
    /// reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception. If the <paramref name="innerException" /> is not a
    /// null reference, the current exception is raised in a catch block that handles the inner exception.
    /// </param>
    public SnakeException(string? message, Exception? innerException)
        : base(message, innerException) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SnakeException" /> class with serialized data.
    /// </summary>
    /// <param name="info">The object that holds the serialized object data.</param>
    /// <param name="context">The contextual information about the source or destination.</param>
    protected SnakeException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
