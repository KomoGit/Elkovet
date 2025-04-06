using Domain.Rules;

namespace Domain.Exceptions
{
	public class PasswordMismatchException(string msg = "Passwords do not match") : Exception(msg), INonSensitiveException
	{
	}
}
