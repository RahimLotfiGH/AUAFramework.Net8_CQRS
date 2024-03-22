using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface IGenerateJwtService
    {
        string Generate(AccountLoginDto loginDto, Client client);
    }
}