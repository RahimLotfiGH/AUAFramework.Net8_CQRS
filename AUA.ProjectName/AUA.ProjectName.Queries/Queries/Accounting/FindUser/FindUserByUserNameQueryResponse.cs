using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ServiceInfrastructure.QueryInfra.Query;
using AutoMapper;

namespace AUA.ProjectName.Queries.Queries.Accounting.FindUser
{
    public class FindUserByUserNameQueryResponse : IQueryResponse, IHaveCustomMappings
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public IEnumerable<string> UserNames { get; set; }

        public bool? IsActive { get; set; }


        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, FindUserByUserNameQueryResponse>()
            .ForMember(p => p.UserNames, p => p.MapFrom(q => q.UserAccounts.Select(a => a.UserName)));
        }
    }
}
