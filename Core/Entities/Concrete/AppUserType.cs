using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete
{
    public class AppUserType : BaseEntity
    {
        public AppUserType()
        {
            AppUsers = new HashSet<AppUser>();
        }
        public string AppUserTypeName { get; set; }
        private ICollection<AppUser> AppUsers { get; set; }
    }
}

