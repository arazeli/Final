using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using T_Shirt_Store.WebUI.AppCode.Providers;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities.Membership;

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

                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());

                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            
            });

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });

            services.AddDbContext<T_Shirt_StoreDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("Default"));
                
            });



            services.AddIdentity<T_ShirtUser, T_ShirtRole>()
                    .AddEntityFrameworkStores<T_Shirt_StoreDbContext>()
                    .AddDefaultTokenProviders();




            services.AddMediatR(this.GetType().Assembly);
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IClaimsTransformation, T_ShirtClaimProvider>();
            services.AddScoped<UserManager<T_ShirtUser>>();
            services.AddScoped<SignInManager<T_ShirtUser>>();
            services.AddScoped<RoleManager<T_ShirtRole>>();

            services.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblies(new[] { this.GetType().Assembly });
            });


            //    services.Configure<IdentityOptions>(cfg=>{

            //        cfg.User.RequireUniqueEmail = true;
            //        //cfg.User.AllowedUserNameCharacters = "";
            //        cfg.Password.RequireNonAlphanumeric = false;
            //        cfg.Password.RequireUppercase = false;
            //        cfg.Password.RequireLowercase = false;
            //        cfg.Password.RequiredLength = 3;
            //        cfg.Password.RequireDigit = false;
            //        cfg.Password.RequiredUniqueChars = 1;

            //        cfg.Lockout.MaxFailedAccessAttempts = 3;
            //        cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0,1,0);


            //    });



            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new System.TimeSpan(0, 3, 0);

            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";

                cfg.ExpireTimeSpan = new System.TimeSpan(240, 24, 5, 22);
                cfg.Cookie.Name = "Shirtapp";
            });

            services.AddAuthentication();
            services.AddAuthorization(cfg =>
            {
                foreach (var policyName in Program.principals)
                {
                    cfg.AddPolicy(policyName, p =>
                    {

                        p.RequireAssertion(handler =>
                        {
                            return handler.User.IsInRole("SuperAdmin")
                            || handler.User.HasClaim(policyName, "1");
                        });

                    });
                }




            });

            services.AddScoped<UserManager<T_ShirtUser>>();
            services.AddScoped<SignInManager<T_ShirtUser>>();

           

            services.AddMediatR(this.GetType().Assembly);

            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IClaimsTransformation, T_ShirtClaimProvider>();

            
           

            services.AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblies(new[] { this.GetType().Assembly });

            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.InitDb();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(name: "default-accessdenied", pattern: "accessdenied.html", defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "accessdenied"

                });

                cfg.MapControllerRoute(name: "default-signin", pattern: "signin.html", defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "signin"

                });
                cfg.MapControllerRoute(name: "default-register", pattern: "register.html", defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "register"

                });
                cfg.MapControllerRoute(name: "default-register-confirm", pattern: "registration-confirm.html", defaults: new
                {
                    area = "",
                    controller = "account",
                    action = "registerConfirm"

                });


                cfg.MapAreaControllerRoute(
                    name: "defaultAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
             );
                cfg.MapControllerRoute("default", pattern: "{controller=home}/{action=index}/{id?}");


            });
        }
    }
}
