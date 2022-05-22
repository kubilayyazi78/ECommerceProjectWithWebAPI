using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppUserAppOperationClaim : UserOperationClaim
    {
        [ForeignKey("OperationClaimId")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
