
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate
{
    [Owned]
    public record PageInf
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
