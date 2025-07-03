namespace FileValidation.Module.Validators.Images
{
    public class WebpValidator : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
            // WEBP magic number: 52 49 46 46
            bool validation = buffer.Length >= 12 &&
                buffer[0] == 0x52 &&
                buffer[1] == 0x49 &&
                buffer[2] == 0x46 &&
                buffer[3] == 0x46;

            return (validation, "webp");
        }
    }
}
