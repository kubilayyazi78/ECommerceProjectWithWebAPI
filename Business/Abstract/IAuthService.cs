using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto);
    }
}
