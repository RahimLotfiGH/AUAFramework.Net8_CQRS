using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccessTokenAggregate;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate
{
    [Table("Client", Schema = SchemaConsts.Accounting)]
    public class Client : DomainEntity<int>
    {
        public string Title { get; set; }

        public Guid ClientIdentity { get; set; }

        public EAppType AppType { get; set; }

        public TokenExpirationTime ClientTokenExpiration { get; set; }

        public string Description { get; set; }

        public bool IsDefault { get; set; }

    }
}
