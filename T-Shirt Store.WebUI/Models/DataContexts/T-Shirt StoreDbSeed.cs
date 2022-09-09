using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.Entities;
using T_Shirt_Store.WebUI.Models.Entities.Membership;

namespace T_Shirt_Store.WebUI.Models.DataContexts
{
    public static class T_Shirt_StoreDbSeed
    {
        //static internal IApplicationBuilder InitMembership(this IApplicationBuilder app)
        //{
        //    using (IServiceScope scope = app.ApplicationServices.CreateScope())
        //    { 
        //        var userManager = scope.ServiceProvider.GetService<UserManager<T_ShirtUser>>();
        //        var roleManager = scope.ServiceProvider.GetService<RoleManager<T_ShirtRole>>();
        //        var configuration = scope.ServiceProvider.GetService<IConfiguration>();


        //        var user = userManager.FindByEmailAsync(configuration["membership:superAdmin"]).Result;

        //        if (user == null)
        //        {
        //            user = new T_ShirtUser
        //            {
        //                Email = configuration["membership:superAdmin"],
        //                UserName = configuration["membership:superAdmin"],
        //                EmailConfirmed = true
        //            };

        //            var identityResult = userManager.CreateAsync(user, configuration["membership:password"]).Result;

        //            if (!identityResult.Succeeded)
        //                return app;

        //        }



        //        var roles = configuration["membership:roles"].Split(",", StringSplitOptions.RemoveEmptyEntries);

        //        foreach (var roleName in roles)
        //        {
        //            var role = roleManager.FindByNameAsync(roleName).Result;

        //            if (role == null)
        //            {
        //                role = new T_ShirtRole
        //                {
        //                    Name = roleName
        //                };


        //                var roleResult = roleManager.CreateAsync(role).Result;

        //                if (roleResult.Succeeded)
        //                {
        //                    userManager.AddToRoleAsync(user, roleName).Wait();

        //                }
        //            }
        //            else if (!userManager.IsInRoleAsync(user, roleName).Result)
        //            {

        //                userManager.AddToRoleAsync(user, roleName).Wait();

        //            }
        //        }


        //    }


        //    return app;
        //}


        static internal IApplicationBuilder InitDb(this IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {

                var db= scope.ServiceProvider.GetRequiredService<T_Shirt_StoreDbContext>();

                InitBrands(db);
                InitPostTags(db);


            }
            return app;

            
        }

        private static void InitPostTags(T_Shirt_StoreDbContext db)
        {
            if (!db.PostTags.Any())
            {
                // < div class="tag-body">
                // <a href = "#" class="tag">women</a>
                // <a href = "#" class="tag">men</a>
                // <a href = "#" class="tag">kids</a>

                //</div>

                db.PostTags.AddRange(new[] { 
                   new PostTag{Name="women"},
                   new PostTag{Name="men"},
                   new PostTag{Name="kids"},

                });
            }
            db.SaveChanges();
        }

        private static void InitBrands(T_Shirt_StoreDbContext db)
        {
            if(!db.Brands.Any())
            {
                db.Brands.Add(new Entities.Brand { 
                
                    Name="Nike"

                });

                db.Brands.Add(new Entities.Brand
                {

                    Name = "Adidas"

                });
                db.SaveChanges();
            }
        }
    }
}
