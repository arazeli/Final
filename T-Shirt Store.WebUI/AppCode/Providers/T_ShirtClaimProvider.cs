using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI.AppCode.Providers
{
    //public class T_ShirtClaimProvider : IClaimsTransformation
    //{
    //    private readonly T_Shirt_StoreDbContext db;
    //    public T_ShirtClaimProvider(T_Shirt_StoreDbContext db)
    //    {
    //        this.db = db;
    //    }

    //    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    //    {
    //        if (principal.Identity.IsAuthenticated && principal.Identity is ClaimsIdentity identity)
    //        {
    //            int userId = principal.GetPrincipalId().Value;

    //            var user = await db.Users.FirstOrDefaultAsync(u=>u.Id==userId);

    //            if (user == null)
    //                goto l1;

    //            var claim = identity.FindFirst(c => !c.Type.Equals(ClaimTypes.NameIdentifier)
    //            && !c.Type.Equals(ClaimTypes.Name)
    //            && !c.Type.Equals(ClaimTypes.Email));

    //            while (claim!=null)
    //            {
    //                identity.RemoveClaim(claim);

    //                 claim = identity.FindFirst(c => !c.Type.Equals(ClaimTypes.NameIdentifier)
    //                 && !c.Type.Equals(ClaimTypes.Name)
    //                 && !c.Type.Equals(ClaimTypes.Email));

    //            }



    //            if (!string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.Surname))
    //            {
    //                identity.AddClaim(new Claim("FullName", $"{user.Name} {user.Surname}"));

    //            }

    //            else if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
    //            {
    //                identity.AddClaim(new Claim("FullName", $"{user.PhoneNumber}"));
    //            }

    //            else
    //            {
    //                identity.AddClaim(new Claim("FullName", $"{user.Email}"));
    //            }


    //            #region Roles
    //            //var roleClain = identity.FindFirst(r => r.Type.Equals(ClaimTypes.Role));

    //            //while (roleClain != null)
    //            //{
    //            //    identity.RemoveClaim(roleClain);
    //            //    roleClain = identity.FindFirst(r => r.Type.Equals(ClaimTypes.Role));
    //            //}

    //            var roles = await (from ur in db.UserRoles
    //                               join r in db.Roles on ur.RoleId equals r.Id
    //                               where ur.UserId == userId
    //                               select r.Name).ToArrayAsync();

    //            foreach (var role in roles)
    //            {
    //                identity.AddClaim(new Claim(ClaimTypes.Role, role));
    //            }
    //            #endregion


    //            #region ClaimBased Realtime reload

    //            var claims = await (from rc in db.RoleClaims
    //                                join ur in db.UserRoles on rc.RoleId equals ur.RoleId
    //                                where ur.UserId == userId && rc.ClaimValue.Equals("1")
    //                                select rc.ClaimType)
    //                          .Union(from uc in db.UserClaims
    //                                 where uc.UserId == userId && uc.ClaimValue.Equals("1")
    //                                 select uc.ClaimType)
    //                          .ToListAsync();

    //            foreach (var claimName in claims)
    //            {
    //                identity.AddClaim(new Claim(claimName, "1"));

    //            }
    //            #endregion


    //        }
    //    l1:
    //        return principal;
    //    }
    //}


    public class T_ShirtClaimProvider : IClaimsTransformation
    {
        private readonly T_Shirt_StoreDbContext db;

        public T_ShirtClaimProvider(T_Shirt_StoreDbContext db)
        {
            this.db = db;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            if (principal.Identity.IsAuthenticated && principal.Identity is ClaimsIdentity currentIdentity)
            {
                var userId = Convert.ToInt32(currentIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value);
                var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId);


                if (user! == null)
                {
                    currentIdentity.AddClaim(new Claim("name", user.Name));
                    currentIdentity.AddClaim(new Claim("surname", user.Surname));
                }

                var role = currentIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
                while (role != null)
                {
                    currentIdentity.RemoveClaim(role);
                    role = currentIdentity.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Role));
                }

                #region Reload Roles for current user

                var currentRoles = (from ur in db.UserRoles
                                    join r in db.Roles on ur.RoleId equals r.Id
                                    where ur.UserId == userId
                                    select r.Name).ToArray();

                foreach (var roleName in currentRoles)
                {
                    currentIdentity.AddClaim(new Claim(ClaimTypes.Role, roleName));
                }
                #endregion

                //Reload Claims for current user

                var currentClaims = currentIdentity.Claims.Where(c => Program.principals.Contains(c.Type))
                    .ToArray();


                foreach (var claim in currentClaims)
                {
                    currentIdentity.RemoveClaim(claim);
                }

                var currentPolicies = await (from uc in db.UserClaims
                                             where uc.UserId == userId
                                             && uc.ClaimValue == "1"
                                             select uc.ClaimType)
                  .Union(from rc in db.RoleClaims
                         join ur in db.UserRoles on rc.RoleId equals ur.RoleId
                         where ur.UserId == userId && rc.ClaimValue == "1"
                         select rc.ClaimType)
                  .ToListAsync();



                foreach (var policy in currentPolicies)
                {
                    currentIdentity.AddClaim(new Claim(policy, "1"));
                }

            }


            return principal;
        }
    }
}
