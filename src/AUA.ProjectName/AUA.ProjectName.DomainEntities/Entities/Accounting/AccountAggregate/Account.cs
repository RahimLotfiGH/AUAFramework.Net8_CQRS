using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate
{
    [Table("Account", Schema = SchemaConsts.Accounting)]
    public class Account : DomainEntity
    {
        public string UserName { get; set; }

        public long AppUserId { get; set; }

        public PasswordCredential PasswordCredential { get; set; }

        public ICollection<AccountRole> UserRoles { get; set; }

        public AppUser AppUser { get; set; }

    }
}
