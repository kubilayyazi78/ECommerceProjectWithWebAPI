using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers.JWT;
using Entities.Dtos.UserDtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetailDto>> GetListAsync();
        Task<UserDto> GetAsync(int id);
        Task<UserDto> AddAsync(UserAddDto userAddDto);
        Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(int id);
        Task<AccessToken> Authenticate(UserForLoginDto userForLoginDto);
    }
}
