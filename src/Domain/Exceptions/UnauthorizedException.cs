using Domain.Rules;

namespace Domain.Exceptions
{
	public class UnauthorizedException(string msg) : Exception(msg), INonSensitiveException
	{
	}
}
