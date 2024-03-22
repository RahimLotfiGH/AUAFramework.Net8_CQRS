using AUA.ProjectName.Common.Consts;
using Serilog;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class ConfigSerilogExtension
    {

        public static void ConfigSerilog(this WebApplicationBuilder builder)
        {
            builder.Host
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(UseConfigFile());
                });

        }

        private static IConfiguration UseConfigFile()
        {
            return new ConfigurationBuilder()
                      .SetBasePath(AppConsts.SeriLogConfigFilePath)
                      .AddJsonFile(AppConsts.SerilogConfigFileName)
                      .Build();
        }
    }
}
