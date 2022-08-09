using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using T_Shirt_Store.WebUI.AppCode.Providers;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg => {
                cfg.ModelBinderProviders.Insert(0,new BooleanBinderProvider());
            
            });

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddDbContext<T_Shirt_StoreDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("Default"));
                
            });



            //services.AddIdentity<T_ShirtUser, T_ShirtRole>()
            //    .AddEntityFrameworkStores<T_Shirt_StoreDbContext>();

           

            services.AddMediatR(this.GetType().Assembly);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblies(new[] { this.GetType().Assembly });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            


            app.UseRouting();
            app.InitDb();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg => {

                

                cfg.MapAreaControllerRoute(
                name: "defaultAdmin",
                areaName:"Admin",
                pattern: "Admin/{controller=dashboard}/{action=Index}/{id?}"
                );

                cfg.MapControllerRoute("default", pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
