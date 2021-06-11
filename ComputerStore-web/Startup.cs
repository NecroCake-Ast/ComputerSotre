using ComputerStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComputerStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connect_settings = "Host=" + Configuration.GetValue("PG_Host", "localhost") + ";"
                                    + "Port=" + Configuration.GetValue("PG_Port", "5432") + ";"
                                    + "Database=" + Configuration.GetValue("PG_Database", "computer_store") + ";"
                                    + "Username=" + Configuration.GetValue("PG_User", "store_guest") + ";"
                                    + "Password=" + Configuration.GetValue("PG_Password", "qwerty") + ";";

            PGContext.SetDBConnectSettings(connect_settings);

            PGContext context = new PGContext();
            services.AddSingleton<IComplectationRepositary>(s => new PGComplectationRepositary(context));

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=List}/{id?}");
                endpoints.MapControllerRoute(
                    name: "complect_details",
                    pattern: "{controller=Home}/{action=Details}/{id}");
            });
        }
    }
}
