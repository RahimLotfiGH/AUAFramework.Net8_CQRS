using AUA.ProjectName.Models.DomainEvents.Base;

namespace AUA.ProjectName.Models.DomainEvents.Accounting
{
    public record LoginDomainEvent : DomainEvent
    {
        public long? UserId { get; set; }

        public string ExecutorCommandName { get; set; }

        public string UserName { get; set; }

        public long AccountId { get; set; }

        public Guid? ClientIdentity { get; set; }

    }
}
