using System.ComponentModel.DataAnnotations.Schema;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Tools.BaseEntities;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate
{
    [Table("ActiveAccessToken", Schema = SchemaConsts.Accounting)]
    public class ActiveAccessToken : DomainEntity
    {
        public long AccountId { get; set; }

        public int ClientId { get; set; }

        public TokenInfo TokenInfo { get; set; }

    }
}
