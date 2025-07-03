namespace FileValidation.Module.Validators.Images
{
    public class PngValidation : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
            // PNG magic number: 89 50 4E 47 0D 0A 1A 0A
            bool validation = buffer.Length >= 8 &&
                   buffer[0] == 0x89 &&
                   buffer[1] == 0x50 &&
                   buffer[2] == 0x4E &&
                   buffer[3] == 0x47 &&
                   buffer[4] == 0x0D &&
                   buffer[5] == 0x0A &&
                   buffer[6] == 0x1A &&
                   buffer[7] == 0x0A;

            return (validation, "png");
        }
    }
}