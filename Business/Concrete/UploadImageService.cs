using Business.Abstract;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UploadImageService : IUploadImageService
    {
        private readonly ILocalizationService _localizationService;

        public UploadImageService(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }



        public async Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileUploadAPIDto fileUploadAPIDto)
        {
            if (fileUploadAPIDto.Files.Length <= 0)
            {
                return new ErrorApiDataResponse<UploadImageDto>(null, _localizationService[ResultCodes.ERROR_ImageNotFound]);
            }

            if (!Directory.Exists(fileUploadAPIDto.WebHostEnvironmentWebRootPath))
            {
                Directory.CreateDirectory(fileUploadAPIDto.WebHostEnvironmentWebRootPath);
            }
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUploadAPIDto.Files.FileName);
            using (FileStream fileStream = File.Create(fileUploadAPIDto.WebHostEnvironmentWebRootPath + newFileName))
            {
                fileUploadAPIDto.Files.CopyTo(fileStream);
                fileStream.Flush();
                UploadImageDto uploadImageDto = new UploadImageDto();
                uploadImageDto.FullPath = await Task.FromResult(fileUploadAPIDto.ApiIPAddress + "/Upload" + newFileName);
                return new SuccessApiDataResponse<UploadImageDto>(uploadImageDto, _localizationService[ResultCodes.HTTP_OK]);
            }
        }
    }
}
