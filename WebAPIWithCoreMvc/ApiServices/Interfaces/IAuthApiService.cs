using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.AppUsers;
using Entities.Dtos.Auths;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
    }
}
