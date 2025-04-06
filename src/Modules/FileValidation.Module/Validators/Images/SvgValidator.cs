using Domain.Attributes;
using FileValidation.Module.Validators;

namespace FileUpload.Module.Validators.Image
{
    [Incomplete("Not yet injected into validator in assembly.")]
    public class SvgValidator : IFileValidator
    {
        public bool Validate(byte[] buffer)
        {
            // SVG magic number: <?xml or <svg
            if (buffer.Length < 5)
                return false;

            if (buffer[0] == 0x3C) // ASCII code for '<'
            {
                // Check for '<?xml' or '<svg' at the beginning of the file
                if (buffer[1] == 0x3F && buffer[2] == 0x78 && buffer[3] == 0x6D && buffer[4] == 0x6C || // '<?xml'
                    buffer[1] == 0x73 && buffer[2] == 0x76 && buffer[3] == 0x67) // '<svg'
                {
                    return true;
                }
            }
            return false;
        }
    }
}