using Domain.Rules;

namespace Domain.Exceptions
{
    public class ConnectionException(string message) : Exception(message), INonSensitiveException
    {
        
    }
}