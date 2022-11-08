using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos.UploadImages
{
    public class FileUploadAPIDto:IDto
    {
        public IFormFile Files  { get; set; }

        public string WebHostEnvironmentWebRootPath { get; set; }

        public string ApiIPAddress { get; set; }


    }
}
