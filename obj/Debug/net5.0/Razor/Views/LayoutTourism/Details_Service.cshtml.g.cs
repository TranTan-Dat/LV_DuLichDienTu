#pragma checksum "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23c7d27ee2176c4f11f573c4cddbe51a40ac467f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LayoutTourism_Details_Service), @"mvc.1.0.view", @"/Views/LayoutTourism/Details_Service.cshtml")]
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
#line 1 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\_ViewImports.cshtml"
using LV_DuLichDienTu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\_ViewImports.cshtml"
using LV_DuLichDienTu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23c7d27ee2176c4f11f573c4cddbe51a40ac467f", @"/Views/LayoutTourism/Details_Service.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e00e21533e8e289c7504da17adc6fd3520d4fa49", @"/Views/_ViewImports.cshtml")]
    public class Views_LayoutTourism_Details_Service : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LV_DuLichDienTu.Models.DichVu>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "HopDongs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
  
    ViewData["Title"] = "Details_Service";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""hero-wrap js-fullheight"" style=""background-image: url('/TourismTemplate/images/bg_4.jpg');"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row no-gutters slider-text js-fullheight align-items-center justify-content-center""
            data-scrollax-parent=""true"">
            <div class=""col-md-9 ftco-animate text-center"" data-scrollax="" properties: { translateY: '70%' }"">
                <p class=""breadcrumbs"" data-scrollax=""properties: { translateY: '30%', opacity: 1.6 }""><span
                        class=""mr-2""><a href=""index.html"">Home</a></span> <span class=""mr-2""><a
                            href=""blog.html"">Blog</a></span> <span>Blog Single</span></p>
                <h1 class=""mb-3 bread"" data-scrollax=""properties: { translateY: '30%', opacity: 1.6 }"">CHI TIẾT DỊCH VỤ
                    </h1>
            </div>
        </div>
    </div>
</div>


<section class=""ftco-section ftco-degree-bg"">
    <div class=""container"">
        <di");
            WriteLiteral("v class=\"row\">\r\n            <div class=\"col-md-8 ftco-animate\">\r\n                <h2 class=\"mb-3\">");
#nullable restore
#line 31 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
                            Write(Model.dv_ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                ");
#nullable restore
#line 32 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
           Write(Html.Raw(@Model.dv_mota));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div> <!-- .col-md-8 -->



            <div class=""col-md-4 sidebar ftco-animate fadeInUp ftco-animated"">
                <div class=""sidebar-box ftco-animate fadeInUp ftco-animated"">
                    <h3>Đăng ký bên dưới</h3>

                    <div");
            BeginWriteAttribute("class", " class=\"", 1610, "\"", 1618, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23c7d27ee2176c4f11f573c4cddbe51a40ac467f6621", async() => {
                WriteLiteral("Click here to show the popup");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
                                                       WriteLiteral(Context.Session.GetString("userID"));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\LayoutTourism\Details_Service.cshtml"
                                                                                                                WriteLiteral(Model.dv_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["service"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-service", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["service"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
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
                    </div>
                </div>
            </div>

        </div>
    </div>
</section>

<div class=""hover_bkgr_fricc"">
    <span class=""helper""></span>
    <div>
        <p>Add any HTML content<br />inside the popup box!</p>
");
            WriteLiteral("\r\n\r\n        <td class=\"navbar-nav ml-auto\">\r\n\r\n            <button class=\"popupCloseButton nav-link\">cancle</button>\r\n            <button class=\"popupCloseButton nav-link\">Đăng Ký</button>\r\n        </td>\r\n        \r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LV_DuLichDienTu.Models.DichVu> Html { get; private set; }
    }
}
#pragma warning restore 1591
