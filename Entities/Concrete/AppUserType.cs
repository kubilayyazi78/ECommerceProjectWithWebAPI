﻿using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUserType : UserType
    {
        public AppUserType()
        {
            PagePermissions = new HashSet<PagePermission>();
            AppUsers = new HashSet<AppUser>();
        }
        public string UserTypeName { get; set; }//UserTypeName
        public ICollection<PagePermission>  PagePermissions { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }

    }
}