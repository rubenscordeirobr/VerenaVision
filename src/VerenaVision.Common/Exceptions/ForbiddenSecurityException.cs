namespace VerenaVision.Common.Exceptions;

public class ForbiddenSecurityException : Exception
{
    public ForbiddenSecurityException(string message) 
        : base(message)
    {
    }
}

