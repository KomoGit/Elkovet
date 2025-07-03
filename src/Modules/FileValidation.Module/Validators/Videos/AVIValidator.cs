namespace FileValidation.Module.Validators.Videos
{
    public class AVIValidator : IFileValidator
    {
        public (bool, string) Validate(byte[] buffer)
        {
            // AVI magic number: 0x52 0x49 0x46 0x46 (RIFF) and 0x41 0x56 0x49 0x20 ('AVI ')
            bool validation = buffer.Length >= 12 &&
                   BitConverter.ToInt32(buffer, 0) == 0x46464952 && // 'RIFF'
                   BitConverter.ToInt32(buffer, 8) == 0x20746d66;    // 'AVI '

            return (validation, "avi");
        }
    }
}