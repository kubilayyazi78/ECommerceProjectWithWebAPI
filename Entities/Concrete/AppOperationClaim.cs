using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim()
        {
            PagePermissions = new HashSet<PagePermission>();
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public ICollection<PagePermission> PagePermissions { get; set; }
        public ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }

    }
}