using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete.BaseEntities
{
    public class AuditTableEntity:BaseEntity,ICreatedEntity,IUpdatedEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
