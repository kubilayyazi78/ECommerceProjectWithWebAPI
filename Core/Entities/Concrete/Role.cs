using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;

namespace Core.Entities.Concrete
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }
    }
}
