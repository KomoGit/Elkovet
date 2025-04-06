using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators.Video
{
    public class WebmValidator : IFileValidator
    {
        public bool Validate(byte[] buffer)
        {
            // WebM magic number: 0x1A45DFA3
            return buffer.Length >= 4 &&
                   buffer[0] == 0x1A &&
                   buffer[1] == 0x45 &&
                   buffer[2] == 0xDF &&
                   buffer[3] == 0xA3;
        }
    }
}