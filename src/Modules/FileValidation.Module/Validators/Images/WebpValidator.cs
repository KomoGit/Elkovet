using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators.Image
{
    public class WebpValidator : IFileValidator
    {
        public bool Validate(byte[] buffer)
        {
            // WEBP magic number: 52 49 46 46
            return buffer.Length >= 12 &&
            buffer[0] == 0x52 &&
            buffer[1] == 0x49 &&
            buffer[2] == 0x46 &&
            buffer[3] == 0x46;
        }
    }
}
