namespace AUA.ProjectName.Models.DomainEvents.Base
{
    public record BaseDomainEvent
    {
        public DateTime IssueTime { get; set; }
        public object Params { get; set; }
    }
}
