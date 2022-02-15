using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{ 
 /// <summary>
/// Veritabanında karşılık gelen tablolarda olacak
/// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
