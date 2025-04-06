using Domain.Exceptions;
using FileValidation.Module.Validators;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace FileValidation.Module
{
    public class FileValidator
    {
        private static readonly List<IFileValidator> Validators = [];
        static FileValidator()
        {
            IEnumerable<Type>? validatorTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IFileValidator).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (Type? type in validatorTypes)
            {
                IFileValidator validator = Activator.CreateInstance(type) as IFileValidator
                    ?? throw new DomainException("No Validators found, cannot proceed. Jonkler");
                Validators.Add(validator);
            }
        }

        public static bool IsAcceptedFormat(IFormFile file)
        {
            byte[] buffer = new byte[512];
            bool isValid = false;

            using (Stream? stream = file.OpenReadStream())
            {
                stream.Read(buffer, 0, buffer.Length);
            }
            //Checks webp on jpeg hence the issue.
            foreach (var validator in Validators)
            {
                if (validator.Validate(buffer))
                {
                    isValid = true;
                    break;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}