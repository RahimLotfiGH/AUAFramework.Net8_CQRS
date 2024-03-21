namespace AUA.ProjectName.DomainEntities.Tools.BaseEntities
{
    public interface IDomainEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }

        bool IsActive { get; set; }
    }

}
