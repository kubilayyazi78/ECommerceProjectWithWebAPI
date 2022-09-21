using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.BaseEntities;

namespace Core.Entities.Concrete
{
    public class AppUser : CreatedUpdatedDeletedEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }

        public Guid RefreshToken { get; set; }
        public int AppUserTypeId { get; set; }
        [ForeignKey("AppUserTypeId")]
        public virtual AppUserType AppUserType { get; set; }
    }
}
