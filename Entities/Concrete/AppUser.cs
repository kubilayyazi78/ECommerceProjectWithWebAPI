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
            AppUserAppRoles = new HashSet<AppUserAppRole>();
        }
        public Guid RefreshToken { get; set; }

        public virtual ICollection<AppUserAppRole> AppUserAppRoles { get; set; }
    }
}
