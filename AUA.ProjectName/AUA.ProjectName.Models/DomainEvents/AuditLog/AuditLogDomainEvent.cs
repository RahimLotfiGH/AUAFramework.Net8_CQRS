using AUA.ProjectName.Models.DomainEvents.Base;

namespace AUA.ProjectName.Models.DomainEvents.AuditLog
{
    public record AuditLogDomainEvent: BaseDomainEvent
    {
        public string CommandName { get; set; }

        public dynamic Request { get; set; }

    }
}
