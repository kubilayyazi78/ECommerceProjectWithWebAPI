using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Helpers.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.UserDtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private AppSettings _appSettings;
        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    DateOfBirth = item.DateOfBirth,
                    UserName = item.UserName,
                    Address = item.Address,
                    Email = item.Email,
                    Id = item.Id
                });
            }

            return userDetailDtos;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                UserDto userDto = new UserDto()
                {
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Gender = user.Gender,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password
                };
                return userDto;
            }

            return null;

        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                LastName = userAddDto.LastName,
                Address = userAddDto.Address,
                //todo:created date ve createduserid düzenlenecek
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                FirstName = userAddDto.FirstName,
                Gender = userAddDto.Gender,
                Password = userAddDto.Password,
                UserName = userAddDto.UserName
            };
            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                LastName = userAdd.LastName,
                Address = userAdd.Address,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                Gender = userAdd.Gender,
                UserName = userAdd.UserName,
                Id = userAdd.Id
            };


            return userDto;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);

            User user = new User()
            {
                LastName = userUpdateDto.LastName,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                Password = userUpdateDto.Password,
                UserName = userUpdateDto.UserName,
                Id = userUpdateDto.Id,
                CreatedDate = getUser.CreatedDate,
                CreatedUserId = getUser.CreatedUserId,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1
            };

            var userUpdate = await _userDal.UpdateAsync(user);

            UserUpdateDto newUserUpdateDto = new UserUpdateDto
            {
                LastName = userUpdate.LastName,
                Address = userUpdate.Address,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                FirstName = userUpdate.FirstName,
                Gender = userUpdate.Gender,
                UserName = userUpdate.UserName,
                Id = userUpdate.Id
            };
            return newUserUpdateDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<AccessToken> Authenticate(UserForLoginDto userForLoginDto)
        {
            var user = await _userDal.GetAsync(x =>
                x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                UserName = user.UserName,
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserId = user.Id
            };

            return await Task.Run(() => accessToken);
        }
    }
}
