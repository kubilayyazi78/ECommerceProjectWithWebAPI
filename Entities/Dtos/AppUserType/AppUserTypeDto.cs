using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos.AppUserType
{
    public class AppUserTypeDto:IDto
    {
        public int Id { get; set; }
        public string UserTypeName { get; set; }
    }
}
