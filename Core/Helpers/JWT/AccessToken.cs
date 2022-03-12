using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
