using FileValidation.Module.Response;

namespace FileValidation.Module.Validators
{
    public interface IFileValidator
    {
        (bool, string) Validate(byte[] buffer);
    }
}