using Domain.Exceptions;
using FileValidation.Module.Response;
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

        public static (bool, string) IsAcceptedFormat(IFormFile file)
        {
            byte[] buffer = new byte[512];
            bool isValid = false;
            string fileType = string.Empty;
            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();


            using (Stream? stream = file.OpenReadStream())
            {
                stream.Read(buffer, 0, buffer.Length);
            }

            foreach (var validator in Validators)
            {
                var validated = validator.Validate(buffer);

                if (validated.Item1)
                {
                    fileType = validated.Item2;
                    if (extension == $".{fileType}")
                    {
                        isValid = true;
                    }
                    break;
                }
                else
                {
                    isValid = false;
                    fileType = "unknown";
                }
            }
            return (isValid, fileType);
        }
    }
}