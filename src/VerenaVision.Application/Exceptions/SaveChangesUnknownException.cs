namespace VerenaVision.Application.Exceptions;

public class SaveChangesUnknownException : Exception
{
    public SaveChangesUnknownException(
        string message)
        : base(message)
    {
    }
}
