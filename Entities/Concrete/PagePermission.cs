using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class PagePermission : AuditEntity
    {
        public int AppUserTypeId { get; set; }
        public int PageId { get; set; }
    }
}