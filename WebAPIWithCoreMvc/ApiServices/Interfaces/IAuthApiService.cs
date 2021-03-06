using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using Entities.Dtos.Auth;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<AppUserDto>> LoginAsync(LoginDto loginDto);
    }
}
