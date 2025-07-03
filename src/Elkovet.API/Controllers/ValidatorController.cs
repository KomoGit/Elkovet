using Application.Repositories;
using Domain.Entities;
using FileValidation.Module;
using Microsoft.AspNetCore.Mvc;

namespace Elkovet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidatorController(IFileUploadRepository fileUploadRepository) : ControllerBase
    {

        [HttpPost("check")]
        public IActionResult CheckFile([FromForm] GenericFile file)
        {
            var validationResponse = FileValidator.IsAcceptedFormat(file.File);
            ValidationResponse response = new()
            {
                IsSuccessful = validationResponse.Item1,
                FileType = validationResponse.Item2
            };

            return Ok(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] GenericFile file)
        {
            var response = await fileUploadRepository.Upload(file.File,"test_files");
            return Ok(response);
        }

        [HttpPost("multiupload")]
        public async Task<IActionResult> UploadFiles([FromForm] GenericFile files)
        {
            var response = await fileUploadRepository.Upload(files.ImagesToAdd, "test_files");
            return Ok(response);
        }
    }
}