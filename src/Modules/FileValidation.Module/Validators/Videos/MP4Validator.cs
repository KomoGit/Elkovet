using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators.Video
{
    public class MP4Validator : IFileValidator
    {
        public bool Validate(byte[] buffer)
        {
            if (buffer.Length < 12)
                return false;

            // Check for the presence of the MPEG-4 file type box (ftyp)
            for (int i = 0; i < buffer.Length - 3; i++)
            {
                if (buffer[i] == 0x66 && // f
                    buffer[i + 1] == 0x74 && // t
                    buffer[i + 2] == 0x79 && // y
                    buffer[i + 3] == 0x70) // p
                {
                    return true;
                }
            }

            return false;
        }
    }
}