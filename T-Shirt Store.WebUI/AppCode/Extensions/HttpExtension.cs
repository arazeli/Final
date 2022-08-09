using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace T_Shirt_Store.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string GetAppLink(this IActionContextAccessor ctx )
        {
            string scheme = ctx.ActionContext.HttpContext.Request.Scheme;
            string host = ctx.ActionContext.HttpContext.Request.Host.ToString();

            return $"{scheme}://{host}";
        }


    }
}
