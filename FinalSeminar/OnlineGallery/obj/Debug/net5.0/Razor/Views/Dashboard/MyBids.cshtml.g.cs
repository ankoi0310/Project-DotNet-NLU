#pragma checksum "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0caf39635e4d9b9a41991bc5fecb0bebfd82ab49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_MyBids), @"mvc.1.0.view", @"/Views/Dashboard/MyBids.cshtml")]
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
#line 1 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
using OnlineGallery.Areas.Identity.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
using OnlineGallery.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0caf39635e4d9b9a41991bc5fecb0bebfd82ab49", @"/Views/Dashboard/MyBids.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0d07fbc517cad37bf602b0d43b0b3b78e3b67e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_MyBids : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("car"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Go to detail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rating"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Go to product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 8 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
  
    ViewData["Title"] = "My Bids";
    ViewData["MyBids"] = "active";
    Layout = "~/Views/Shared/_DashboardLayout.cshtml";

    var user = await userManager.GetUserAsync(User);

    var allAuction = context.AuctionRecords.Where(e => e.UserId.Equals(userManager.GetUserId(User))).Select(e => e.AuctionId).Distinct().ToList();
    var inProgressAuction = context.Auctions.Where(e => e.Status && allAuction.Contains(e.Id)).ToList();
    var passAuction = context.Auctions.Where(e => !e.Status && allAuction.Contains(e.Id)).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""dash-bid-item dashboard-widget mb-40-60"">
    <div class=""header"">
        <h4 class=""title"">My Bids</h4>
    </div>
    <ul class=""button-area nav nav-tabs"">
        <li>
            <a href=""#in-progress"" data-toggle=""tab"" class=""custom-button active"">In progress</a>
        </li>
        <li>
            <a href=""#past"" data-toggle=""tab"" class=""custom-button"">Past</a>
        </li>
    </ul>
</div>
<div class=""tab-content"">
    <div class=""tab-pane fade show active"" id=""in-progress"">
        <div class=""row mb-30-none justify-content-center"">
");
#nullable restore
#line 36 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
             foreach (var item in inProgressAuction)
            {
                var lastBidPrice = item.AuctionRecords.Select(e => e.BidPrice.Value).Last();
                var bids = context.AuctionRecords.Where(e => e.AuctionId == item.Id).Count();
                var product = context.Products.Find(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-sm-10 col-md-6\">\r\n                    <div class=\"auction-item-2\">\r\n                        <div class=\"auction-thumb\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab497249", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab497465", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1912, "~/images/", 1912, 9, true);
#nullable restore
#line 44 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 1921, product.Image, 1921, 14, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1850, "~/Home/AuctionDetail/", 1850, 21, true);
#nullable restore
#line 44 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 1871, item.Id, 1871, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab4910464", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 46 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                 if (user != null && Tools.IsMyFavorites(context, user.Id, product.Id))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i class=\"fas fa-star\"></i>\r\n");
#nullable restore
#line 49 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i class=\"far fa-star\"></i>\r\n");
#nullable restore
#line 53 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1990, "~/Home/AddOrRemoveFavorites/", 1990, 28, true);
#nullable restore
#line 45 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 2018, product.Id, 2018, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2035, "like-feature-", 2035, 13, true);
#nullable restore
#line 45 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 2048, product.Id, 2048, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2072, "return", 2072, 6, true);
            AddHtmlAttributeValue(" ", 2078, "jQueryAjaxFavorites(\'", 2079, 22, true);
#nullable restore
#line 45 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 2100, Url.Action("AddOrRemoveFavorites", "Home", new { product.Id }, Context.Request.Scheme), 2100, 87, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 2187, "\');", 2187, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"auction-content\">\r\n                            <h6 class=\"title font-weight-bolder\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab4914675", async() => {
#nullable restore
#line 58 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                                                            Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2851, "~/Home/ProductDetail/", 2851, 21, true);
#nullable restore
#line 58 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 2872, product.Id, 2872, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </h6>
                            <div class=""bid-area"">
                                <div class=""bid-amount"">
                                    <div class=""icon"">
                                        <i class=""flaticon-auction""></i>
                                    </div>
                                    <div class=""amount-content"">
                                        <div class=""current"">Current Bid</div>
                                        <div class=""amount"">");
#nullable restore
#line 67 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                       Write(lastBidPrice.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                                <div class=""bid-amount"">
                                    <div class=""icon"">
                                        <i class=""flaticon-money""></i>
                                    </div>
                                    <div class=""amount-content"">
                                        <div class=""current"">Buy Now</div>
                                        <div class=""amount"">");
#nullable restore
#line 76 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                       Write(product.DefaultPrice.Value.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                    </div>
                                </div>
                            </div>
                            <div class=""countdown-area"">
                                <div class=""countdown"">
                                    <div");
            BeginWriteAttribute("id", " id=\"", 4326, "\"", 4348, 2);
            WriteAttributeValue("", 4331, "counter", 4331, 7, true);
#nullable restore
#line 82 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
WriteAttributeValue("", 4338, item.Id, 4338, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-countdown=\"");
#nullable restore
#line 82 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                                           Write(item.ClosingDay.Value.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n                                </div>\r\n                                <span class=\"total-bids\">");
#nullable restore
#line 84 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                    Write(bids);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Bids</span>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 89 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"tab-pane fade\" id=\"past\">\r\n        <div class=\"row justify-content-center mb-30-none\">\r\n");
#nullable restore
#line 94 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
             foreach (var item in passAuction)
            {
                var lastBidPrice = item.AuctionRecords.Select(e => e.BidPrice.Value).Last();
                var bids = context.AuctionRecords.Where(e => e.AuctionId == item.Id).Count();
                var product = context.Products.Find(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-sm-10 col-md-6\">\r\n                    <div class=\"auction-item-2\">\r\n                        <div class=\"auction-thumb\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab4920886", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab4921103", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 5378, "~/images/", 5378, 9, true);
#nullable restore
#line 102 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 5387, product.Image, 5387, 14, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5316, "~/Home/AuctionDetail/", 5316, 21, true);
#nullable restore
#line 102 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 5337, item.Id, 5337, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0caf39635e4d9b9a41991bc5fecb0bebfd82ab4924105", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 104 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                 if (user != null && Tools.IsMyFavorites(context, user.Id, product.Id))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i class=\"fas fa-star\"></i>\r\n");
#nullable restore
#line 107 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i class=\"far fa-star\"></i>\r\n");
#nullable restore
#line 111 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5456, "~/Home/AddOrRemoveFavorites/", 5456, 28, true);
#nullable restore
#line 103 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 5484, product.Id, 5484, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5501, "like-feature-", 5501, 13, true);
#nullable restore
#line 103 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 5514, product.Id, 5514, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onclick", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5538, "return", 5538, 6, true);
            AddHtmlAttributeValue(" ", 5544, "jQueryAjaxFavorites(\'", 5545, 22, true);
#nullable restore
#line 103 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
AddHtmlAttributeValue("", 5566, Url.Action("AddOrRemoveFavorites", "Home", new { product.Id }, Context.Request.Scheme), 5566, 87, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 5653, "\');", 5653, 3, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"auction-content\">\r\n                            <h6 class=\"title\">\r\n                                <span class=\"font-weight-bolder\">");
#nullable restore
#line 116 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                            Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n                                <span>Time: ");
#nullable restore
#line 117 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                       Write(item.StartDay.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 117 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                                                     Write(item.ClosingDay.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </h6>
                            <div class=""bid-area"">
                                <div class=""bid-amount"">
                                    <div class=""icon"">
                                        <i class=""flaticon-auction""></i>
                                    </div>
                                    <div class=""amount-content"">
                                        <div class=""current"">Total Bids</div>
                                        <div class=""amount"">");
#nullable restore
#line 126 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                       Write(bids);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Bids</div>
                                    </div>
                                </div>
                                <div class=""bid-amount"">
                                    <div class=""icon"">
                                        <i class=""flaticon-money""></i>
                                    </div>
                                    <div class=""amount-content"">
                                        <div class=""current"">Last Price</div>
                                        <div class=""amount"">");
#nullable restore
#line 135 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
                                                       Write(lastBidPrice.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 142 "F:\NLU\.NET\Project-DotNet-NLU\FinalSeminar\OnlineGallery\Views\Dashboard\MyBids.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
