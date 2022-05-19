using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete
{
    public class UserRole:BaseEntity,IUpdatedEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
