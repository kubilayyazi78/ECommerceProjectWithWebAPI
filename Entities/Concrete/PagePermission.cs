using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class PagePermission : AuditEntity
    {
        public int UserTypeID { get; set; }
        public int PageID { get; set; }
        public int OperationClaimID { get; set; }
        public Page Page { get; set; }
        public AppUserType AppUserType { get; set; }
        public AppOperationClaim AppOperationClaim { get; set; }
    }
}