using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.AppUser;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAppUserApiService
    {
        Task<ApiDataResponse<List<AppUserDto>>> GetListAsync();
    }
}