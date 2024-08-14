namespace MishFit.Exceptions;

public class InvalidIncomingParameterException : Exception
{
    public InvalidIncomingParameterException(string? message) : base(message)
    {
    }
}