using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class GenericFile
    {
        public IFormFile? File { get; set; }
        public List<IFormFile>? ImagesToAdd { get; set; }
    }
}
