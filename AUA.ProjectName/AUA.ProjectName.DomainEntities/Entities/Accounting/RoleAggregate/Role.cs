using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleUserAccessAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.RoleAggregate
{
    [Table("Role", Schema = SchemaConsts.Accounting)]
    public sealed class Role : DomainEntity<int>
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public ICollection<AccountRole> UserRoles { get; set; }

        public ICollection<RoleUserAccess> UserRoleAccess { get; set; }
    }
}
