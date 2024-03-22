using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.RoleAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate
{
    [Table("AccountRole", Schema = SchemaConsts.Accounting)]
    public class AccountRole : DomainEntity
    {
        public long UserAccountId { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Account UserAccount { get; set; }


    }
}
