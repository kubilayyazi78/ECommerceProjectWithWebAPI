using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hash
{
    public interface IHashService
    {
        string CreateHash(string plainText);
        bool CompareHash(string hashedText,string plainText );

    }
}
