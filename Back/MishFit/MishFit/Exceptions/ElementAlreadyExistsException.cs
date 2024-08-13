namespace MishFit.Exceptions;

public class ElementAlreadyExistsException : Exception
{
    public ElementAlreadyExistsException(string? message) : base(message)
    {
    }
}