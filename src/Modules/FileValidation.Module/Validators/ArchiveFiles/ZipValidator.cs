namespace FileValidation.Module.Validators.ArchiveFiles
{
    public class ZipValidator : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
             bool validation = buffer.Length >= 4 &&
               buffer[0] == 0x50 &&
               buffer[1] == 0x4B &&
               buffer[2] == 0x03 &&
               buffer[3] == 0x04;

            return (validation, "zip");
        }
    }
}