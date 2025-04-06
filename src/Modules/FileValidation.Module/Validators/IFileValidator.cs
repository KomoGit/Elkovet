namespace FileValidation.Module.Validators
{
    public interface IFileValidator
    {
        bool Validate(byte[] buffer);
    }
}