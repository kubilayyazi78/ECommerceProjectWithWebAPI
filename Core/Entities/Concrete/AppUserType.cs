﻿using Core.Entities.BaseEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class AppUserType : AuditEntity
    {
        #region Constructor
        public AppUserType()
        {
            AppUsers = new HashSet<AppUser>();
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();

        }
        #endregion

        #region Properties
        [Required]
        [StringLength(50)]
        public string AppUserTypeName { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }


        #endregion
    }
}