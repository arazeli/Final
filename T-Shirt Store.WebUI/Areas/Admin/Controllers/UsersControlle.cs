using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Shirt_Store.WebUI.Models.DataContexts;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using T_Shirt_Store.WebUI.Models.Entities.Membership;
using T_Shirt_Store.WebUI;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly T_Shirt_StoreDbContext db;

        public UsersController(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }

        [Authorize("admin.users.index")]
        public async Task<IActionResult> Index()
        {
            var data = await db.Users.ToListAsync();
            return View(data);
        }




        [Authorize("admin.users.details")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await db.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (User == null)
            {
                return NotFound();
            }


            ViewBag.Roles = await (from r in db.Roles
                                   join ur in db.UserRoles
                                   on new { RoleId = r.Id, UserId = user.Id } equals new { ur.RoleId, ur.UserId } into lJoin
                                   from lj in lJoin.DefaultIfEmpty()
                                   select Tuple.Create(r.Id, r.Name, lj != null)).ToListAsync();

            ViewBag.principals = (from p in Program.principals
                                  join uc in db.UserClaims on new { ClaimValue = "1", ClaimType = p, UserId = user.Id } equals new { uc.ClaimValue, uc.ClaimType, uc.UserId } into lJoin
                                  from lj in lJoin.DefaultIfEmpty()
                                  select Tuple.Create(p, lj != null)).ToList();
            return View(user);
        }




        [Authorize("admin.users.setrole")]
        [HttpPost]
        [Route("/user-set-role")]
        public async Task<IActionResult> SetRole(int userId, int roleId, bool selected)
        {

            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var role = await db.Roles.FirstOrDefaultAsync(r => r.Id == roleId);

            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xetali Sorgu"
                });
            }


            if (role == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xetali Sorgu"
                });
            }


            if (selected)
            {
                if (await db.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adli istifadechi '{role.Name}' adli roldadir "
                    });
                }

                else
                {
                    db.UserRoles.Add(new T_ShirtUserRole
                    {
                        UserId = userId,
                        RoleId = roleId
                    });

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"'{user.Name} {user.Surname}' adli istifadechi '{role.Name}' rola elave edildi "
                    });
                }
            }
            else
            {
                var userRole = await db.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

                if (userRole == null)
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adli istifadechi '{role.Name}'adli rolda deyil "
                    });
                }
                else
                {
                    db.UserRoles.Remove(userRole);

                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        error = false,
                        message = $"'{user.Name} {user.Surname}' adli istifadechi '{role.Name}' roldan silindi "
                    });
                }
            }

        }


        [Authorize("admin.users.principal")]
        [HttpPost]
        [Route("/user-set-principal")]
        public async Task<IActionResult> SetPrincipal(int userId, string principalName, bool selected)
        {

            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var hasPrincipal = Program.principals.Contains(principalName);

            if (user == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Xetali Sorgu"
                });
            }


            if (!hasPrincipal)
            {
                return Json(new
                {
                    error = true,
                    message = "Xetali Sorgu"
                });
            }



            if (selected)
            {
                if  (await db.UserClaims.AnyAsync(uc=> uc.UserId == userId && uc.ClaimType.Equals(principalName) && uc.ClaimValue.Equals("1")))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{user.Name} {user.Surname}' adli istifadechi '{principalName}' adli səlahiyyətə malikdir "
                    });
                }
                else
                {
                    db.UserClaims.Add(new T_ShirtUserClaim { 
                      UserId = userId,
                      ClaimType = principalName,
                      ClaimValue = "1"
                    });
                    await db.SaveChangesAsync();
                    return Json(new
                    {
                        error = false,
                        message = $"'{principalName}' adli səlahiyyət '{user.Name} {user.Surname}'  adli istifadəçiyə şamil edildi "
                    });
                }
            }

            else
            {
                var userClaim = await db.UserClaims.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.ClaimType.Equals(principalName) && uc.ClaimValue.Equals("1"));

                if (userClaim==null)
                {
                    return Json(new
                    {
                        error = true,
                        message = $"'{principalName}' adli səlahiyyət '{user.Name} {user.Surname}' adli səlahiyyətə malik deyil "
                    });

                }
                else
                {
                    db.UserClaims.Remove(userClaim);
                    await db.SaveChangesAsync();
                    return Json(new
                    {
                        error = false,
                        message = $" '{user.Name} {user.Surname}'  adli istifadəçidən '{principalName}' adli səlahiyyət alindi "
                    });
                }

                  
               
            }
        }

    }
}

