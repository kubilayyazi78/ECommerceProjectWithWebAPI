using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim()
        {
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }
    }
}
