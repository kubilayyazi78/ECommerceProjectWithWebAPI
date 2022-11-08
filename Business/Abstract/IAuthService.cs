using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auths;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
        Task<ApiDataResponse<AccessToken>> RegisterAsync(RegisterDto registerDto,string password);
        Task<AccessToken> CreateAccessTokenAsync(AppUser appUser);
    }
}
