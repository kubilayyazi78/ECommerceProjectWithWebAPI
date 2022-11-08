﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.AppOperationClaimDtos;
using Entities.Dtos.AppUsers;
using Entities.Dtos.Auths;

namespace Business.Abstract
{
    public interface IAppUserService
    {
        Task<ApiDataResponse<IEnumerable<AppUserDto>>> GetListAsync();
        Task<ApiDataResponse<IEnumerable<AppUserDto>>> GetListDetailAsync();
        Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<AppUser>> GetAsync(Expression<Func<AppUser, bool>> filter);
        Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto);
        Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto userUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

        Task<List<OperationClaimDto>> GetRolesAsync(Core.Entities.Concrete.AppUser user);
    }
}
