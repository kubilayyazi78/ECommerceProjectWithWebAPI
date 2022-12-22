using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : AuditEntity
    {
        #region Properties
        [Required]
        public int AppUserTypeId { get; set; }

        [Required]
        public int AppOperationClaimId { get; set; }

        [Required]
        public string Status { get; set; }
        #endregion

        #region Relationships
        [ForeignKey("AppOperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("AppUserTypeId")]
        public virtual AppUserType AppUserType { get; set; }
        #endregion
    }
}