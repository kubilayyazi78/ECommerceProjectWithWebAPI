using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Entities.Dtos.AppUserTypes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAppUserTypeService
    {
        Task<ApiDataResponse<List<AppUserTypeDto>>> GetListAsync();
        Task<ApiDataResponse<AppUserType>> GetAsync(Expression<Func<AppUserType, bool>> filter);
        Task<ApiDataResponse<AppUserTypeDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<AppUserTypeDto>> AddAsync(AppUserTypeAddDto userAddTypeDto);
        Task<ApiDataResponse<AppUserTypeUpdateDto>> UpdateAsync(AppUserTypeUpdateDto userUpdateTypeDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
    }
}