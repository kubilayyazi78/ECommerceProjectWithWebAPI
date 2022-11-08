using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Dtos.AppOperationClaimDtos;
using Entities.Dtos.AppUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAppUserDal : EfBaseRepository<AppUser, ECommerceDbContext>, IAppUserDal
    {
        public async Task<List<OperationClaimDto>> GetRolesAsync(Core.Entities.Concrete.AppUser user)
        {
            using (var context = new ECommerceDbContext())
            {
                var result = from appUserTypeAppOperationClaim in context.AppUserTypeAppOperationClaims
                             join appOperationClaim in context.AppOperationClaims on appUserTypeAppOperationClaim
                                 .AppOperationClaimId equals appOperationClaim.Id
                             join appUserType in context.AppUserTypes on appUserTypeAppOperationClaim.AppUserTypeId equals
                                 appUserType.Id
                             where appUserTypeAppOperationClaim.AppUserTypeId == user.AppUserTypeId
                             select new OperationClaimDto
                             {
                                 Id = appOperationClaim.Id,
                                 Name = appOperationClaim.Name + "." + appUserTypeAppOperationClaim.Status
                             };
                return await result.ToListAsync();
            }

        }

        public async Task<List<AppUserDto>> GetListDetailAsync()
        {
            using (var context = new ECommerceDbContext())
            {
                var result = from appUser in context.AppUsers
                             join appUserType in context.AppUserTypes on appUser.AppUserTypeId equals appUserType.Id
                             select new AppUserDto
                             {
                                 Id = appUser.Id,
                                 AppUserTypeName = appUserType.AppUserTypeName,
                                 AppUserTypeId = appUser.AppUserTypeId,
                                 Email = appUser.Email,
                                 FirstName = appUser.FirstName,
                                 GsmNumber = appUser.GsmNumber,
                                 LastName = appUser.LastName,
                                 UserName = appUser.UserName,
                                 ProfileImageUrl = appUser.ProfileImageUrl
                             };
                return await result.ToListAsync();
            }

        }
    }
}
