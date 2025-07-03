namespace FileValidation.Module.Validators.Images
{
    public class JpegValidator : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
            // JPEG magic number: FF D8 FF
            bool validation = buffer.Length >= 3 &&
                   buffer[0] == 0xFF &&
                   buffer[1] == 0xD8 &&
                   buffer[2] == 0xFF;

            return (validation, "jpeg");
        }
    }
}