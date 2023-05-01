using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Page : BaseEntity
    {
        public Page()
        {
            PagePermissions = new HashSet<PagePermission>();
            PageLanguages = new HashSet<PageLanguage>();
        }
        public string PageURL { get; set; }
        public int? ParentID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }

        public PageType PageType { get; set; }
        public ICollection<PagePermission> PagePermissions { get; set; }
        public ICollection<PageLanguage> PageLanguages { get; set; }

    }
}