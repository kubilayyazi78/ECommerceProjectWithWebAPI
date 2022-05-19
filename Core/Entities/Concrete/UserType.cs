using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete
{
    public class UserType : BaseEntity
    {
        public string UserTypeName { get; set; }
    }
}

