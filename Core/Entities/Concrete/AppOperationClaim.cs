using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;

namespace Core.Entities.Concrete
{
    public class AppOperationClaim : BaseEntity
    {
        public string Name { get; set; }
        public AppOperationClaim()
        {
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }
    }
}
