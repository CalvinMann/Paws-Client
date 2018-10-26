using Akka.Actor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetDesk.Paws.Client.VetSpa.ActorModels.Abstractions;
using PetDesk.Paws.Client.VetSpa.SignalR;
using PetDesk.Pawss.Client.VetSpa.ActorModels.Abstactions;

namespace PetDesk.Paws.Client.VetSpa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR(config => config.EnableDetailedErrors = true);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors();

            //Application Services
            services.AddSingleton(ActorSystem.Create("AppointmentSystem"));
            services.AddSingleton<IAppointmentEventPusher, AppointmentEventPusher>();
            services.AddSingleton<IAppointmentActorSystem, AppointmentActorSystem>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });


            app.UseSignalR(routes =>
            {
                routes.MapHub<AppointmentHub>("/appointmentHub");
            });

            app.UseCors();

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                //spa.UseSpaPrerendering(options =>
                //{
                //    options.BootModulePath = $"{spa.Options.SourcePath}/dist-server/main.bundle.js";
                //    options.BootModuleBuilder = env.IsDevelopment()
                //        ? new AngularCliBuilder(npmScript: "build:ssr")
                //        : null;
                //    options.ExcludeUrls = new[] { "/sockjs-node" };
                //});

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
