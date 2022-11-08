using System;
using System.Security.AccessControl;
using Core.Entities;
using Entities.Dtos.AppUserTypes;

namespace Entities.Dtos.AppUsers
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public string AppUserTypeName { get; set; }
        public int AppUserTypeId { get; set; }
        
    }
}