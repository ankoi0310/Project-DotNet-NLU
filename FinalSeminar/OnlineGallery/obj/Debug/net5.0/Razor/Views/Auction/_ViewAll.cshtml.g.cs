#pragma checksum "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9689f2d856a3785bc0a60e7d8f6d09aa2065faf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auction__ViewAll), @"mvc.1.0.view", @"/Views/Auction/_ViewAll.cshtml")]
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
#nullable restore
#line 1 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
using OnlineGallery.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9689f2d856a3785bc0a60e7d8f6d09aa2065faf2", @"/Views/Auction/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d07fbc517cad37bf602b0d43b0b3b78e3b67e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Auction__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineGallery.Models.Auction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxSoldConfirm(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
  
    ViewBag.Count = 0;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-body"">
                <table id=""auction"" class=""table table-bordered table-striped"">
                    <thead>
                        <tr>
                            <th class=""align-middle text-center"">
                                No.
                            </th>
                            <th class=""align-middle text-center"">
                                ");
#nullable restore
#line 24 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                           Write(Html.DisplayNameFor(item => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </th>
                            <th class=""align-middle text-center"">Start Day</th>
                            <th class=""align-middle text-center"">Closing Day</th>
                            <th class=""align-middle text-center"">
                                ");
#nullable restore
#line 29 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                           Write(Html.DisplayNameFor(item => item.StartingPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th class=\"align-middle text-center\">\r\n                                ");
#nullable restore
#line 32 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                           Write(Html.DisplayNameFor(item => item.StepPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th class=\"align-middle text-center\">\r\n                                ");
#nullable restore
#line 35 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                           Write(Html.DisplayNameFor(item => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1538, "\"", 1648, 5);
            WriteAttributeValue("", 1548, "showInPopup(\'", 1548, 13, true);
#nullable restore
#line 38 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
WriteAttributeValue("", 1561, Url.Action("CreateOrUpdate", "Auction", null, Context.Request.Scheme), 1561, 70, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1631, "\',", 1631, 2, true);
            WriteAttributeValue(" ", 1633, "\'New", 1634, 5, true);
            WriteAttributeValue(" ", 1638, "Auction\')", 1639, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success btn-block\"><i class=\"fas fa-plus\"></i></a>\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 43 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                         foreach (var item in Model)
                        {
                            var product = await context.Products.FindAsync(item.ProductId);
                            ViewBag.Count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"align-middle text-center\">\r\n                                    ");
#nullable restore
#line 49 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(ViewBag.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle\">\r\n                                    ");
#nullable restore
#line 52 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n                                    ");
#nullable restore
#line 55 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(item.StartDay.Value.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n                                    ");
#nullable restore
#line 58 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(item.ClosingDay.Value.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n                                    ");
#nullable restore
#line 61 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(item.StartingPrice.Value.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n                                    ");
#nullable restore
#line 64 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                               Write(item.StepPrice.Value.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 67 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                     if (item.Status)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"font-weight-bolder text-success\">On process</span>\r\n");
#nullable restore
#line 70 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                    }
                                    else
                                    {
                                        if (item.StartDay.Value.CompareTo(DateTime.Now) > 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"font-weight-bolder text-secondary\">Not started yet</span>\r\n");
#nullable restore
#line 76 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"font-weight-bolder text-danger\">Closed</span>\r\n");
#nullable restore
#line 80 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td class=\"align-middle text-center\">\r\n");
#nullable restore
#line 84 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                     if (item.StartDay.Value.CompareTo(DateTime.Now) > 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 4416, "\"", 4540, 5);
            WriteAttributeValue("", 4426, "showInPopup(\'", 4426, 13, true);
#nullable restore
#line 86 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
WriteAttributeValue("", 4439, Url.Action("CreateOrUpdate", "Auction", new { item.Id }, Context.Request.Scheme), 4439, 81, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4520, "\',", 4520, 2, true);
            WriteAttributeValue(" ", 4522, "\'Update", 4523, 8, true);
            WriteAttributeValue(" ", 4530, "Auction\')", 4531, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Edit</a>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9689f2d856a3785bc0a60e7d8f6d09aa2065faf214383", async() => {
                WriteLiteral("\r\n                                            <input type=\"submit\" value=\"Delete\" class=\"btn btn-warning\" />\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 90 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 93 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Auction\_ViewAll.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n        <!-- /.card -->\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ApplicationDbContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineGallery.Models.Auction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
