using System.Runtime.Serialization;

namespace MishFit.Exceptions;

public class ElementAlreadyExistsException : Exception
{
    public ElementAlreadyExistsException()
    {
    }

    [Obsolete("Obsolete")]
    protected ElementAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ElementAlreadyExistsException(string? message) : base(message)
    {
    }

    public ElementAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}