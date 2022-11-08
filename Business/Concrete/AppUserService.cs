using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.SecuredOperation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Core.Utilities.Security.Hash.Sha512;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Entities.Dtos.AppUsers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppUserService : IAppUserService
    {
        #region DI
        private readonly IAppUserDal _appUserDal;
        private AppSettings _appSettings;
        private IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public AppUserService(IAppUserDal appUserDal, IOptions<AppSettings> appSettings, IMapper mapper, ILocalizationService localizationService)
        {
            _appUserDal = appUserDal;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _localizationService = localizationService;
        }
        #endregion

        // [CacheAspect(10)]
        [SecuredOperationAspect("AppUser.List")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<IEnumerable<AppUserDto>>> GetListAsync()
        {

            //throw new UnauthorizedAccessException("Unauthorized");

            var response = await _appUserDal.GetListAsync();
            var userDtos = _mapper.Map<List<AppUserDto>>(response);
            return new SuccessApiDataResponse<IEnumerable<AppUserDto>>(data:userDtos,message: _localizationService[ResultCodes.HTTP_OK],resultCount:userDtos.Count);
        }
        // [CacheAspect(10)]
        [SecuredOperationAspect("AppUser.List")]
        [LogAspect(typeof(FileLogger))]
        public async Task<ApiDataResponse<IEnumerable<AppUserDto>>> GetListDetailAsync()
        {

            var response = await _appUserDal.GetListDetailAsync();
            var userDtos = _mapper.Map<List<AppUserDto>>(response);
            return new SuccessApiDataResponse<IEnumerable<AppUserDto>>(userDtos, message: _localizationService[ResultCodes.HTTP_OK],resultCount: userDtos.Count);
        }
        public async Task<ApiDataResponse<AppUser>> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
            var user = await _appUserDal.GetAsync(filter);

                return new SuccessApiDataResponse<AppUser>(data:user,user is null ? _localizationService[ResultCodes.ERROR_UserNotFound]:_localizationService[ResultCodes.HTTP_OK], resultCount: user ==null ? 0 : 1 );
        }

        public async Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id)
        {
            var user = await _appUserDal.GetAsync(x => x.Id == id);

            var userDto = _mapper.Map<AppUserDto>(user);
            return new SuccessApiDataResponse<AppUserDto>(data: userDto, userDto is null ? _localizationService[ResultCodes.ERROR_UserNotFound] : _localizationService[ResultCodes.HTTP_OK], resultCount: userDto == null ? 0 : 1);

        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.GetListAsync")]
        [ValidationAspect(typeof(AppUserAddDtoValidator))]
        public async Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto)
        {
            byte[] passwordHash, passwordSalt;
            var user = _mapper.Map<AppUser>(userAddDto);
            Sha512Helper.CreatePasswordHash(userAddDto.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            var userAdd = await _appUserDal.AddAsync(user);
            var userDto = _mapper.Map<AppUserDto>(userAdd);
            return new SuccessApiDataResponse<AppUserDto>(userDto, _localizationService[ResultCodes.HTTP_OK]);
        }

        public async Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto userUpdateDto)
        {
            var getUser = await _appUserDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<AppUser>(userUpdateDto);
            user.CreatedDate = getUser.CreatedDate;
            user.CreatedUserId = getUser.CreatedUserId;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedUserId = 1;
            var resultUpdate = await _appUserDal.UpdateAsync(user);
            var userUpdateMap = _mapper.Map<AppUserUpdateDto>(resultUpdate);
            return new SuccessApiDataResponse<AppUserUpdateDto>(userUpdateMap, _localizationService[ResultCodes.HTTP_OK]);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _appUserDal.DeleteAsync(id), _localizationService[ResultCodes.HTTP_OK]);
        }

        public async Task<List<OperationClaimDto>> GetRolesAsync(Core.Entities.Concrete.AppUser user)
        {
            return await _appUserDal.GetRolesAsync(user);
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
