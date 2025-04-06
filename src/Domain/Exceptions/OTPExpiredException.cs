namespace Domain.Exceptions
{
	public class OTPExpiredException(string msg = "OTP has expired, request a new code.") : Exception(msg)
	{
	}
}
