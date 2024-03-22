using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger;
using Serilog;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class AppConfigExtension
    {
        public static void Configuration(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(AppConsts.ExceptionHandlerUrl);
            
            app.DefaultConfiguration();

            app.UseSwaggerAndUI();

            app.MvcConfiguration();

            app.UseSerilogRequestLogging();

            app.UseCors();

        }

        private static void DefaultConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

        }

        private static void UseCors(this IApplicationBuilder app)
        {
            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());
        }


        private static void MvcConfiguration(this IApplicationBuilder app)
        {

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });

        }

    }
}
