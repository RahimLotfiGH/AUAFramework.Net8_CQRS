namespace AUA.ProjectName.DomainEntities.Tools.BaseEntities
{

    public class DomainEntity<TPrimaryKey> : BaseDomainEntity<TPrimaryKey>, IAuditInfo, ICreationAudited
    {
        public DateTime RegistrationDate { get; set; }

        public long? CreatorUserId { get; set; }

    }
}