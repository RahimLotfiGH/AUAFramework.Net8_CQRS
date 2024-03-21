using AUA.Infrastructure.ConfigMapping;
using AUA.Infrastructure.Registrations;
using AUA.ProjectName.Commands.Utilities;
using AUA.ProjectName.Models.BaseModel.BaseDto;
using AUA.ProjectName.Queries.Utilities;
using AUA.ProjectName.Reports.Utilities;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class AutoMapperRegistration
    {
        public static void RegistrationAutoMapper(this IServiceCollection services)
        {
            AddTypesToManager();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        private static void AddTypesToManager()
        {
            TypeManager.AddType(typeof(BaseEntityDto));
            TypeManager.AddType(typeof(IQueryPathHelper));
            TypeManager.AddType(typeof(IReportPathHelper));
            TypeManager.AddType(typeof(ICommandPathHelper));


        }

    }
}
