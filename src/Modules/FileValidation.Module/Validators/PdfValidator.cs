using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators
{
	public class PdfValidator : IFileValidator
	{
		public bool Validate(byte[] buffer)
		{
			return buffer.Length >= 4 &&
				   buffer[0] == 0x25 &&
				   buffer[1] == 0x50 &&
				   buffer[2] == 0x44 &&
				   buffer[3] == 0x46;
		}
	}
}