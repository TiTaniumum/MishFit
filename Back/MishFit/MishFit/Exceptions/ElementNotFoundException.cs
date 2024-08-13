using System.Runtime.Serialization;

namespace MishFit.Exceptions;

public class ElementNotFoundException : Exception
{
    public ElementNotFoundException()
    {
    }

    [Obsolete("Obsolete")]
    protected ElementNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ElementNotFoundException(string? message) : base(message)
    {
    }

    public ElementNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}