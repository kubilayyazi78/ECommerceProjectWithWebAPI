using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using System;
using System.Threading.Tasks;
using Core.Utilities.Security.Hash.Sha512;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        #region DI
        private IAppUserService _appUserService;
        private ITokenService _tokenService;
        private IMapper _mapper;

        public AuthService(IAppUserService appUserService, IMapper mapper, ITokenService tokenService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        #endregion

        [ValidationAspect(typeof(LoginDtoValidator))]
        public async Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto)
        {
            var user = await _appUserService.GetAsync(x => x.UserName == loginDto.UserName);
            if (user.Data == null)
            {
                return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNotFound);
            }
            else
            {
                if (!Sha512Helper.VerifyPasswordHash(loginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
                {
                    return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNotFound);
                }

                var appUser = _mapper.Map<AppUser>(user.Data);
                var accessToken = await CreateAccessTokenAync(appUser);
                return new SuccessApiDataResponse<AccessToken>(accessToken, Messages.SystemLoginSuccessful);
            }

        }

        //private async Task<ApiDataResponse<AppUserDto>> UpdateToken(ApiDataResponse<AppUserDto> user)
        //{
        //    var accessToken = _tokenService.CreateToken(user.Data.Id, user.Data.UserName);
        //    var userUpdateDto = _mapper.Map<UserUpdateDto>(user.Data);
        //    userUpdateDto.TokenExpireDate = accessToken.Expiration;
        //    userUpdateDto.Token = accessToken.Token;
        //    userUpdateDto.UpdatedUserId = user.Data.Id;
        //    var resultUserUpdateDto = await _appUserService.UpdateAsync(userUpdateDto);
        //    var userDto = _mapper.Map<AppUserDto>(resultUserUpdateDto.Data);
        //    return new SuccessApiDataResponse<AppUserDto>(userDto, Messages.SystemLoginSuccessful);
        //}

        public async Task<AccessToken> CreateAccessTokenAync(AppUser appUser)
        {
            var roles = await _appUserService.GetRolesAsync(appUser);

            var accessToken = _tokenService.CreateToken(appUser, roles);

            return accessToken;
        }
    }
}
