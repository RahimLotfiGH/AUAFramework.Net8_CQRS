using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate
{
    [Table("AppUser", Schema = SchemaConsts.Accounting)]
    public sealed class AppUser : DomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserContact UserContact { get; set; }

        public ICollection<Account> UserAccounts { get; set; }


        public void Update(string firstName, string lastName, UserContact userContact)
        {
            FirstName = firstName;
            LastName = lastName;
            UserContact = userContact;
        }

    }
}
