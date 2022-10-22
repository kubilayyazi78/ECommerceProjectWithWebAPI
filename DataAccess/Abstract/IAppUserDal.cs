using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Entities.Dtos.AppOperationClaimDto;
using Entities.Dtos.AppUser;

namespace DataAccess.Abstract
{
    public interface IAppUserDal : IBaseRepository<AppUser>
    {
        Task<List<OperationClaimDto>> GetRolesAsync(Core.Entities.Concrete.AppUser user);
        Task<List<AppUserDto>> GetListDetailAsync();
    }
}
