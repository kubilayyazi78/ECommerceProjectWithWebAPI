using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Concrete;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync();
        Task<ApiDataResponse<UserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<AppUser, bool>> filter);
        Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto);
        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
     //   Task<ApiDataResponse<AccessToken>> Authenticate(LoginDto userForLoginDto);
    }
}
