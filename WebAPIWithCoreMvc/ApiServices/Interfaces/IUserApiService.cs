using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Dtos.AppUser;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
   public interface IUserApiService
   {
       Task<List<AppUserDetailDto>> GetListAsync();
   }
}
