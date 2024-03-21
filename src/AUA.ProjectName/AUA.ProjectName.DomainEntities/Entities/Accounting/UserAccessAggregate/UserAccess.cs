using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleUserAccessAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate
{
    [Table("UserAccess", Schema = SchemaConsts.Accounting)]
    public sealed class UserAccess : DomainEntity<int>
    {
        public int? ParentId { get; set; }

        public EUserAccess AccessCode { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsIndirect { get; set; }

        public PageInf PageInf { get; set; }

        public ICollection<RoleUserAccess> RoleAccesses { get; set; }

    }
}
