using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    
    public class AppUser : User
    {
        public AppUser()
        {
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public Guid RefreshToken { get; set; }

        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }
    }
}
