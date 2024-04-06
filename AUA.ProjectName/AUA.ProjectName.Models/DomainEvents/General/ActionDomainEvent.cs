using AUA.ProjectName.Models.DomainEvents.Base;

namespace AUA.ProjectName.Models.DomainEvents.General
{
    public record ActionDomainEvent : DomainEvent
    {
        public long? UserId { get; set; }

        public string UserName { get; set; }
          
        public string ClientId { get; set; }

        public string ActionName { get; set; }


    }
}
