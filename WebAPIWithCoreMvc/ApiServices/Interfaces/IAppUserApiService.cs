using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.AppUsers;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAppUserApiService
    {
        Task<ApiDataResponse<List<AppUserDto>>> GetListAsync();

        Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync();

        Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto appUserAddDto);
    }
}