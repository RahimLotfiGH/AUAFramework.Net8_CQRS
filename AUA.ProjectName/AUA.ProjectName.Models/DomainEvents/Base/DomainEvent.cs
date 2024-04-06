namespace AUA.ProjectName.Models.DomainEvents.Base
{
    public record DomainEvent: IDomainEvent
    {
        public DateTime IssueTime { get; set; }
        public object Params { get; set; }
    }
}
