using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.RoleUserAccessAggregate
{
    [Table("RoleUserAccess", Schema = SchemaConsts.Accounting)]
    public sealed class RoleUserAccess : DomainEntity<int>
    {
        public int RoleId { get; set; }

        public int UserAccessId { get; set; }

        public Role Role { get; set; }

        public UserAccess UserAccess { get; set; }
    }
}
