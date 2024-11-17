namespace Ordering.Domain.Exceptions;

internal class DomainException : Exception
{
    public DomainException(string message) : base($"Domain exception: \"{message}\" throws from Domain Layer ") 
    { 

    }

}

