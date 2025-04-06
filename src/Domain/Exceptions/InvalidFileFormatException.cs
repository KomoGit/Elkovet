using Domain.Rules;

namespace Domain.Exceptions
{
    public class InvalidFileFormatException : Exception, INonSensitiveException, IReversableException
	{
		public InvalidFileFormatException()
		   : base("File format is not supported.")
		{

		}
	}
}