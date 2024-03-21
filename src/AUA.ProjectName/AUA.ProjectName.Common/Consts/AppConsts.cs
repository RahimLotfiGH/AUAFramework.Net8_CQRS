namespace AUA.ProjectName.Common.Consts
{
    public static class AppConsts
    {
        public const string AppName = "AUA Frameworke";
  
        public const string AppDllName = "AUA.ProjectName.WebApi";

        public const string ConnectionStrings = "ConnectionStrings";

        public const string AuthorizationAccessTokenName = "AuthorizationToken";

        public const string EfDbConnection = "EntityFrameWorkConnection";

        public const string DapperDbConnection = "DapperConnection";
        
        public static string AppSettingsFilePath => $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";

        public const string StringDataTypeName = "string";

        public const string CookieName = ".AUA.Session";

        public const string ExceptionHandlerUrl = "/Api/V1/ExceptionHandler/Index";

        public static string[] SplitDateTimeChar => new[] { "/", "\\", ":", "-"," " };

        public static string SeriLogConfigFilePath = Directory.GetCurrentDirectory() + "/ConfigFiles";

        public static string SerilogConfigFileName = "Serilog.json";

        public static string LogSplitter = " >> ";

        public static string ExceptionLogMessage = "Exception Serialize: exceptionId =";

        


    }
}
