﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Dtos.AppUserTypes
{
    public class AppUserTypeDto:IDto
    {
        public int Id { get; set; }
        public string AppUserTypeName { get; set; }
    }
}