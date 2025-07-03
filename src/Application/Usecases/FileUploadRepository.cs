using Application.Repositories;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SharedKernel.Domain.Settings;
using SharedKernel.Domain;
using FileValidation.Module;

namespace Application.UseCases
{
    public class FileUploadRepository(IOptions<FileSettings> settings, IHttpContextAccessor httpContextAccessor) : IFileUploadRepository
    {
        private readonly string OS_Path = settings.Value.Path;
        private const string FolderPath = "files";
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<string> Upload(IFormFile file, string _PATH)
        {
            string unique = RenameFile(file.FileName);
            string path = $"{OS_Path}/{_PATH}";
            CreateFolder(path);

            if(!FileValidator.IsAcceptedFormat(file).Item1)
               throw new InvalidFileFormatException();

            await ProcessFile(file, unique, path);
            return $"{_httpContextAccessor.HttpContext.Request.GetBaseUrl()}/{FolderPath}/{_PATH}/{unique}";
        }

        public async Task<(IEnumerable<string>, int)> Upload(IEnumerable<IFormFile> files, string _PATH)
        {
            if (files == null)
            {
                throw new InvalidFileFormatException();
            }
            string path = $"{OS_Path}/{_PATH}";
            int err = 0;
            CreateFolder(path);
            List<string> fileNames = [];
            foreach (IFormFile? file in files)
            {
                string unique = RenameFile(file.FileName);
                if (FileValidator.IsAcceptedFormat(file).Item1) //Item1 is the boolean: (IsSuccessful)
                {
                    await ProcessFile(file, unique, path);
                    fileNames.Add($"{_httpContextAccessor.HttpContext.Request.GetBaseUrl()}/{FolderPath}/{_PATH}/{unique}");
                }
                else
                    err++;
            }
            return (fileNames.AsEnumerable(), err);
        }

        public void DeleteFile(string FileName)
        {
            Uri uri = new(FileName);
            string absolutePath = uri.AbsolutePath;
            string realPath = absolutePath.Replace(FolderPath, "/project_files/");
            if (File.Exists(realPath))
            {
                File.Delete(realPath);
                return;
            }
            throw new FileNotFoundException();
        }

        private async static Task ProcessFile(IFormFile file, string newfilename, string _PATH)
        {
            using FileStream stream = new(Path.Combine(_PATH, newfilename.Replace(" ", "")), FileMode.Create);
            await file.CopyToAsync(stream);
        }

        private static void CreateFolder(string _PATH)
        {
            Directory.CreateDirectory(_PATH);
        }

        private static string RenameFile(string filename)
        {
            return $"{GenerateRandomCombination()}-{filename}";
        }

        private static string GenerateRandomCombination()
        {
            Random random = new();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            string randomCharacters = new([.. Enumerable.Range(0, 1).Select(_ => characters[random.Next(characters.Length)])]);

            string randomNumbers = new([.. Enumerable.Range(0, 2).Select(_ => numbers[random.Next(numbers.Length)])]);

            string combination = randomCharacters + randomNumbers;

            // Shuffle the combination
            combination = new string(combination.ToCharArray().OrderBy(c => random.Next()).ToArray());

            return combination;
        }
    }
}