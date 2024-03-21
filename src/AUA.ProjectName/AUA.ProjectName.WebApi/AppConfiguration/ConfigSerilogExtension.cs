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

            // if Use save in the File "logs/log.txt"
            //builder.UseCodeConfig();

        }


        //private static void UseCodeConfig(this WebApplicationBuilder builder)
        //{
        //    builder.Host.UseSerilog((context, configuration) =>
        //            configuration.ReadFrom.Configuration(context.Configuration)
        //           .Enrich.FromLogContext()
        //           .WriteTo.Console()
        //           .WriteTo.Debug(outputTemplate: DateTime.Now.ToString(CultureInfo.InvariantCulture))
        //           .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day));

        //}


        private static IConfiguration UseConfigFile()
        {
            return new ConfigurationBuilder()
                      .SetBasePath(AppConsts.SeriLogConfigFilePath)
                      .AddJsonFile(AppConsts.SerilogConfigFileName)
                      .Build();
        }
    }
}
