using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete.BaseEntities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
