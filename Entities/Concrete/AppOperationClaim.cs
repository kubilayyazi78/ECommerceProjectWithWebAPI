﻿using System;
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
            AppUserAppOperationClaims = new HashSet<AppUserAppOperationClaim>();
        }
        public virtual ICollection<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }
}
