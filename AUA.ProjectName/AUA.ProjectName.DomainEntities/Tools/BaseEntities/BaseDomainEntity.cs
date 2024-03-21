namespace AUA.ProjectName.DomainEntities.Tools.BaseEntities
{
    public class BaseDomainEntity<TPrimaryKey> : IDomainEntity<TPrimaryKey>
    {

        public TPrimaryKey Id { get; set; }

        public bool IsActive { get; set; }

    }
}
