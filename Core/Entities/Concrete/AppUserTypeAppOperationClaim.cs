using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : BaseEntity,IUpdatedEntity
    {
        #region Properties
        public int AppUserTypeId { get; set; }
        public int AppOperationClaimId { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; } 
        #endregion

        public string Status { get; set; }
        [ForeignKey("AppOperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("AppUserTypeId")]
        public virtual AppUserType AppUserType { get; set; }
    }
}
