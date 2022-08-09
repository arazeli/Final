using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Models.DataContexts
{
    public static class T_Shirt_StoreDbSeed
    {
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
