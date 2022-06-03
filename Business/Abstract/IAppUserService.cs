using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Concrete;
using Entities.Dtos.AppOperationClaimDto;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAppUserService
    {
        Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync();
        Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<AppUserDto>> GetAsync(Expression<Func<AppUser, bool>> filter);
        Task<ApiDataResponse<AppUserDto>> AddAsync(UserAddDto userAddDto);
        Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

        Task<List<OperationClaimDto>> GetRolesAsync(User user);
    }
}
