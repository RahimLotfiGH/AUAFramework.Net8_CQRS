using AUA.ProjectName.Models.DomainEvents.Base;

namespace AUA.ProjectName.Models.DomainEvents.AuditLog
{
    public record FullAuditLogDomainEvent: DomainEvent
    {
        public string CommandName { get; set; }
        public dynamic Request { get; set; }
        public dynamic Response { get; set; }

    }
}
