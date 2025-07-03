using Microsoft.AspNetCore.Http;

namespace Application.Repositories
{
    //Singleton
    public interface IFileUploadRepository
    {
        #region Upload
        /// <summary>
        /// Upload to specific path
        /// </summary>
        /// <param name="file"></param>
        /// <param name="_PATH"></param>
        /// <returns></returns>
        Task<string> Upload(IFormFile file, string _PATH);
        /// <summary>
        /// Multiupload files, no default PATH
        /// </summary>
        /// <param name="files"></param>
        /// <param name="_PATH"></param>
        /// <returns></returns>
        Task<(IEnumerable<string>, int)> Upload(IEnumerable<IFormFile> files, string _PATH);
        #endregion
        void DeleteFile(string FileName);
    }
}