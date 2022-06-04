using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Utilities.Security.Hash.Sha512;
using Entities.Concrete;
using Entities.Dtos.AppUser;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        #region DI
        private readonly IAppUserService _appUserService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IAppUserService appUserService, IMapper mapper, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
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
                var accessToken = await CreateAccessTokenAsync(appUser);
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

        public async Task<AccessToken> CreateAccessTokenAsync(AppUser appUser)
        {
            var roles = await _appUserService.GetRolesAsync(appUser);

            var accessToken = _tokenService.CreateToken(appUser, roles);

            return accessToken;
        }

        public async Task<ApiDataResponse<AccessToken>> RegisterAsync(RegisterDto registerDto, string password)
        {
            var user = await _appUserService.GetAsync(x => x.UserName == registerDto.UserName);
            if (user.Data != null)
            {
                return new ErrorApiDataResponse<AccessToken>(null, Messages.UserNameAlreadyExsist);
            }

            byte[] passwordHash, passwordSalt;
            Sha512Helper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var appUser = _mapper.Map<AppUser>(registerDto);

            appUser.PasswordHash = passwordHash;
            appUser.PasswordSalt = passwordSalt;
            appUser.CreatedDate = DateTime.Now;
            appUser.CreatedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var appUserAddDto = _mapper.Map<AppUserAddDto>(appUser);
            var appUserAdd = _appUserService.AddAsync(appUserAddDto);
            if (appUserAdd == null)
            {
                return new ErrorApiDataResponse<AccessToken>(null, Messages.NotAdded);
            }

            var appUserAccessToken = _mapper.Map<AppUser>(appUserAdd);
            var newAccessToken = await CreateAccessTokenAsync(appUserAccessToken);
            return new SuccessApiDataResponse<AccessToken>(newAccessToken, Messages.UserRegistered);
        }

    }
}
