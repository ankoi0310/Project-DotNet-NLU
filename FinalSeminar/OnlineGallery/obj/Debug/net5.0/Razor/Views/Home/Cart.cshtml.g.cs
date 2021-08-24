#pragma checksum "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d1058e619509cc7b9b84412ac4c4b213280ab5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Cart), @"mvc.1.0.view", @"/Views/Home/Cart.cshtml")]
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
#line 1 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\_ViewImports.cshtml"
using OnlineGallery;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\_ViewImports.cshtml"
using OnlineGallery.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d1058e619509cc7b9b84412ac4c4b213280ab5b", @"/Views/Home/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d07fbc517cad37bf602b0d43b0b3b78e3b67e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineGallery.Models.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
  
    ViewData["Title"] = "Cart";

    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--============= Hero Section Starts Here =============-->\r\n<div class=\"hero-section\">\r\n    <div class=\"container\">\r\n        <ul class=\"breadcrumb\">\r\n            <li>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d1058e619509cc7b9b84412ac4c4b213280ab5b3931", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n            <li>\r\n                <span>Contact Us</span>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"bg_img hero-bg bottom_center\" data-background=\"");
#nullable restore
#line 21 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                                          Write(Url.Content("~/assets/images/banner/hero-bg.png"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""></div>
</div>
<!--============= Hero Section Ends Here =============-->
<!--============= Contact Section Starts Here =============-->
<section class=""contact-section padding-bottom"">
    <div class=""container"">
        <div class=""contact-wrapper padding-top padding-bottom mt--100 mt-lg--440"">
            <div class=""section-header"">
                <h2 class=""title"">Products In Cart</h2>
            </div>
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <table class=""table table-bordered table-striped"" style=""table-layout: fixed;"">
                                <thead>
                                    <tr>
                                        <th class=""align-middle text-center"">
                                            No.
                                        </th>
                                        <th class=""align-middle text-center");
            WriteLiteral("\">\r\n                                            ");
#nullable restore
#line 42 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                       Write(Html.DisplayNameFor(item => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th class=\"align-middle text-center\">\r\n                                            ");
#nullable restore
#line 45 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                       Write(Html.DisplayNameFor(item => item.DefaultPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th></th>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody id=\"cart-body\">\r\n");
#nullable restore
#line 51 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                     if (Model.ToList().Count != 0)
                                    {
                                        foreach (var item in Model)
                                        {
                                            count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td class=\"align-middle text-center\">");
#nullable restore
#line 57 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                                                                Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td class=\"align-middle\">");
#nullable restore
#line 58 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td class=\"align-middle\">");
#nullable restore
#line 59 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                                                    Write(item.DefaultPrice.Value.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n                                                    <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2875, "\"", 2988, 4);
            WriteAttributeValue("", 2885, "return", 2885, 6, true);
            WriteAttributeValue(" ", 2891, "removeFromCart(\'", 2892, 17, true);
#nullable restore
#line 61 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
WriteAttributeValue("", 2908, Url.Action("RemoveFromCart", "Home", new { item.Id }, Context.Request.Scheme), 2908, 78, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2986, "\')", 2986, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"remove-cart text-danger\">Remove</button>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 64 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                        }
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td colspan=\"4\" class=\"align-middle text-center\">No data available in table</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 71 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Home\Cart.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                        <!-- /.card-body -->
                    </div>
                    <!-- /.card -->
                </div>
            </div>
        </div>
    </div>
</section>
<!--============= Contact Section Ends Here =============-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineGallery.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591