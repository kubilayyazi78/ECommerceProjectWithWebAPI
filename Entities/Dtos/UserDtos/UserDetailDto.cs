﻿using Core.Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.UserDtos
{
    public class UserDetailDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
    }
}