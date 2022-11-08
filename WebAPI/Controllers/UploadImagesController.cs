using Business.Abstract;
using Entities.Dtos.UploadImages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadImageService _uploadImageService;

        public UploadImagesController(IUploadImageService uploadImageService, IWebHostEnvironment webHostEnvironment)
        {
            _uploadImageService = uploadImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUploadImage([FromForm] FileUploadAPIDto fileUploadAPIDto)
        {
            fileUploadAPIDto.ApiIPAddress = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            fileUploadAPIDto.WebHostEnvironmentWebRootPath = _webHostEnvironment.WebRootPath + "\\Upload\\";
            var result = await _uploadImageService.UploadImageAsync(fileUploadAPIDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
