#pragma checksum "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2067ab2a86c65bbe4a502310d0eaebe7dd218017"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BlogPosts_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/BlogPosts/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using T_Shirt_Store.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using T_Shirt_Store.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using T_Shirt_Store.WebUI.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using T_Shirt_Store.WebUI.AppCode.Modules.BrendModule;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2067ab2a86c65bbe4a502310d0eaebe7dd218017", @"/Areas/Admin/Views/BlogPosts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"372cd6f9f3dd416dffd6c34c7ece356614bcd377", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_BlogPosts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BlogPost>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/assets/libs/sweetalert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




<div class=""page-header"">
    <div class=""row align-items-end"">
        <div class=""col-lg-8"">
            <div class=""page-header-title"">
                <div class=""d-inline"">
                    <h4>Brands</h4>
                    <span>
                        Brandler
                    </span>
                </div>
            </div>
        </div>
        <div class=""col-lg-4"">
            <div class=""page-header-breadcrumb"">
                <ul class=""breadcrumb-title"">
                    <li class=""breadcrumb-item"" style=""float: left;"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2067ab2a86c65bbe4a502310d0eaebe7dd2180178075", async() => {
                WriteLiteral(" <i class=\"feather icon-home\"></i> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </li>

                    <li class=""breadcrumb-item"" style=""float: left;"">
                        <a href=""#!"">Brendler</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<div class=""page-body"">

    <div class=""card p-3"">
        <div class=""card-block table-border-style"">
            <div class=""table-responsive"">
                <table class=""table table-hover"">
                    <thead>
                        <tr>
                            <th>Image</th>
                            <th>Title</th>
                            <th>Category</th>
                            <th>Body</th>
                            <th class=""table-operations"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2067ab2a86c65bbe4a502310d0eaebe7dd21801710274", async() => {
                WriteLiteral("\r\n                                    Create\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 59 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr data-entity-id=\"");
#nullable restore
#line 61 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                                           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <td class=\"cell-sm\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2067ab2a86c65bbe4a502310d0eaebe7dd21801712445", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2066, "~/uploads/images/", 2066, 17, true);
#nullable restore
#line 63 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
AddHtmlAttributeValue("", 2083, item.ImagePath, 2083, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"cell-sm\">\r\n                                    ");
#nullable restore
#line 66 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                               Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"cell-sm\">\r\n                                    ");
#nullable restore
#line 69 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                               Write(item.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"cell-sm ellipse\">\r\n                                    ");
#nullable restore
#line 72 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                               Write(item.Body.HtmlToPlainText().ToEllipse());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td class=\"table-operations\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2067ab2a86c65bbe4a502310d0eaebe7dd21801715456", async() => {
                WriteLiteral("\r\n                                        Edit\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2067ab2a86c65bbe4a502310d0eaebe7dd21801717851", async() => {
                WriteLiteral("\r\n                                        Details\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3115, "\"", 3167, 5);
            WriteAttributeValue("", 3125, "removeEntity(event,", 3125, 19, true);
#nullable restore
#line 82 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
WriteAttributeValue("", 3144, item.Id, 3144, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3152, ",\'", 3152, 2, true);
#nullable restore
#line 82 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
WriteAttributeValue("", 3154, item.Title, 3154, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3165, "\')", 3165, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">\r\n                                        Delete\r\n                                    </a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 87 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("js", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2067ab2a86c65bbe4a502310d0eaebe7dd21801721781", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 102 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
     if (true)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"     <script>
      function removeEntity(ev,entityId,name)
      {
          swal({
              title: ""Əminsiniz ki silinsin?"",
              text: `${name} adli qeyd silinecek.Razisiniz?`,
              icon: ""warning"",
              buttons: true,
              dangerMode: true,
          })
              .then((willDelete) => {
                  if (willDelete) {
                      //admin/brands/delete/1
                      $.ajax({
                          url:`");
#nullable restore
#line 118 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
                          Write(Url.Action("Delete"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/${entityId}`,
                          type: 'post',
                          success:function(response)
                          {
                              if (response.error==true){
                                  toastr.error(response.message,""Xəta!"");
                                  return;
                              }

                              toastr.success(response.message,""Ugur"");
                              $(`tr[data-entity-id=${entityId}]`).remove();
                          },
                          error: function (response)
                          {
                              console.warn(response);
                          }
                      })
                  }
              });
        }

        </script>
");
#nullable restore
#line 140 "C:\Users\hp\Desktop\T-Shirt Store Solution\T-Shirt Store.WebUI\Areas\Admin\Views\BlogPosts\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BlogPost>> Html { get; private set; }
    }
}
#pragma warning restore 1591