using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUploadImageService
    {
        Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileUploadAPIDto fileUploadAPIDto);
    }
}
