using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ProjectName.Queries.Queries.Accounting.UserContacts;

namespace AUA.ProjectName.Queries.Mapping.Accounting
{
    public static class AppUserMapping
    {
        public static UserContactQueryResponse ToUserContactQueryResponse(this UserContact contact)
        {
            return new UserContactQueryResponse
            {
                Email = contact.Email,
                Phone = contact.Phone,
            };
        }
    }
}
