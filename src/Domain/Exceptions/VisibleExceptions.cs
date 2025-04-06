using Domain.Rules;

namespace Domain.Exceptions
{
    public class VisibleExceptions(string message) : Exception(message), INonSensitiveException
    {
    }
}