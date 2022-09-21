using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Core.Utilities.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException()
        {
        }

        public UnAuthorizedException(string message) : base(message)
        {
        }

        public UnAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
    }
}
