using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppRole : Role
    {
        public AppRole()
        {
            AppUserAppRoles = new HashSet<AppUserAppRole>();
        }
        public virtual ICollection<AppUserAppRole> AppUserAppRoles { get; set; }
    }
}
