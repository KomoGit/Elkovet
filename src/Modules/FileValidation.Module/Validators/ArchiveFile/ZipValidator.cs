using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators.ArchiveFile
{
    public class ZipValidator : IFileValidator
    {
        public bool Validate(byte[] buffer)
        {
            return buffer.Length >= 4 &&
               buffer[0] == 0x50 &&
               buffer[1] == 0x4B &&
               buffer[2] == 0x03 &&
               buffer[3] == 0x04;
        }
    }
}