using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using AUA.ProjectName.Models.BaseModel.BaseDto;
using AutoMapper;

namespace AUA.ProjectName.Models.DynamicAggregate.Accounting
{
    public class AccountLoginDto : BaseEntityDto, IHaveCustomMappings
    {
        public PasswordCredential PasswordCredential { get; set; }

        public string UserName { get; set; }

        public long AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<EUserAccess> UserAccessCodes { get; set; }

        public IEnumerable<int> RoleIds { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<Account, AccountLoginDto>()
                         .ForMember(p => p.FirstName, p => p.MapFrom(q => q.AppUser.FirstName))
                         .ForMember(p => p.LastName, p => p.MapFrom(q => q.AppUser.LastName))
                         .ForMember(p => p.FirstName, p => p.MapFrom(q => q.AppUser.FirstName))
                         .ForMember(p => p.RoleIds, p => p.MapFrom(q => q.UserRoles.Select(r => r.Role.Id)))
                         .ForMember(p => p.UserAccessCodes, p => p.MapFrom(q => q.UserRoles.
                          SelectMany(a => a.Role.UserRoleAccess.Select(s => s.UserAccess.AccessCode)).Distinct()));

        }
    }
}
