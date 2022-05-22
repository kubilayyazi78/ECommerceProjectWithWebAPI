﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        #region DI
        private readonly IAppUserDal _userDal;
        private AppSettings _appSettings;
        private IMapper _mapper;
        public UserService(IAppUserDal userDal, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        #endregion

        [CacheAspect(10)]
        public async Task<ApiDataResponse<IEnumerable<UserDetailDto>>> GetListAsync()
        {
            var response = await _userDal.GetListAsync();
            var userDetailDtos = _mapper.Map<IEnumerable<UserDetailDto>>(response);
            return new SuccessApiDataResponse<IEnumerable<UserDetailDto>>(userDetailDtos, Messages.Listed);
        }

        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<User, bool>> filter)
        {
            var user = await _userDal.GetAsync(filter);

            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }
            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);
        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Messages.Listed);
            }

            return new ErrorApiDataResponse<UserDto>(null, Messages.NotListed);

        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.GetListAsync")]
        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<AppUser>(userAddDto);
            //todo:created date ve createduserid düzenlenecek
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            var userAdd = await _userDal.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd);
            return new SuccessApiDataResponse<UserDto>(userDto, Messages.Added);
        }

        public async Task<ApiDataResponse<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<AppUser>(userUpdateDto);
            //Todo: createddate ve createdid düzenlenecek
            //user.Password = getUser.Password;
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
           // user.Token = userUpdateDto.Token;
           // user.TokenExpireDate = userUpdateDto.TokenExpireDate;
            var resultUpdate = await _userDal.UpdateAsync(user);
            var userUpdateMap = _mapper.Map<UserUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<UserUpdateDto>(userUpdateMap, Messages.Updated);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _userDal.DeleteAsync(id), Messages.Deleted);
        }

        //public async Task<ApiDataResponse<AccessToken>> Authenticate(LoginDto userForLoginDto)
        //{
        //    var user = await _userDal.GetAsync(x =>
        //        x.UserName == userForLoginDto.UserName && x.Password == userForLoginDto.Password);

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    AccessToken accessToken = new AccessToken()
        //    {
        //        Token = tokenHandler.WriteToken(token),
        //        UserName = user.UserName,
        //        Expiration = (DateTime)tokenDescriptor.Expires,
        //        UserId = user.Id
        //    };

        //    return new SuccessApiDataResponse<AccessToken>(await Task.Run(() => accessToken), Messages.Listed);
        //}


    }
}
