using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AUA.ProjectName.DataLayer.Tools
{
    public static class DbContextConfiguration
    {

        public static void DbContextConfig(this IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationEfContext>(option =>
            {
                option.UseSqlServer(AppConfiguration.EfConnectionString);
            });
        }
    }
}
