namespace FileValidation.Module.Validators.Documents
{
	public class PdfValidator : IFileValidator
	{
		public (bool, string) Validate(byte[] buffer)
		{
			bool validation = buffer.Length >= 4 &&
				   buffer[0] == 0x25 &&
				   buffer[1] == 0x50 &&
				   buffer[2] == 0x44 &&
				   buffer[3] == 0x46;

			return (validation, "pdf");
		}
	}
}