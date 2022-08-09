using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static HtmlString GetCategoriesRaw(this List<Category> categories)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul style=\"padding: 0px;\">");
            foreach(var category in categories.Where(c=>c.ParentId==null))
            {
                AppendCategory(category,sb);
            }
            sb.Append("</ul>");
            return new HtmlString(sb.ToString());

        }
        static void AppendCategory(Category category,StringBuilder sb)
        {
            bool hasChild = category.Children.Any();

            sb.Append($"<li {(hasChild?"class=category":"")}><a href=\"#\" class=\"accordion\">{category.Name}</a>");



            if (hasChild)
            {
                sb.Append("<div class=\"panel\">");
                sb.Append("<ul class=\"subcategory\">");

                foreach (var item in category.Children)
                { 
                    sb.Append($"<li><a href=\"#\">{item.Name}</a></li>");
                }
                
                sb.Append("</ul>");
                sb.Append("</div>");
            }
            sb.Append("</li>");

        }
    }

    
}
