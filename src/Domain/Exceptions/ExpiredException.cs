using Domain.Rules;

namespace Domain.Exceptions
{
	public class ExpiredException(string msg) : Exception(msg), INonSensitiveException
	{
	}
}
