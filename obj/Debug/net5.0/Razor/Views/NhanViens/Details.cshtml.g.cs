#pragma checksum "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d6ee13384bb9e6fa6d869495ef59077b8fa15e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NhanViens_Details), @"mvc.1.0.view", @"/Views/NhanViens/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d6ee13384bb9e6fa6d869495ef59077b8fa15e3", @"/Views/NhanViens/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e00e21533e8e289c7504da17adc6fd3520d4fa49", @"/Views/_ViewImports.cshtml")]
    public class Views_NhanViens_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LV_DuLichDienTu.Models.NhanVien>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("class", " class=\"", 2030, "\"", 2038, 0);
            EndWriteAttribute();
            WriteLiteral(@">
    <div class=""row"">
        <div class=""col-md-10 center-margin"">
            <div class=""x_panel"">
                <div class=""x_title"">
                    <h2>Thông tin chi tiết nhân viên</h2>
                    <div class=""clearfix""></div>
                </div>
                <div class=""x_content"">
                    <br>
                    <div id=""demo-form2""  class=""form-horizontal form-label-left""");
            BeginWriteAttribute("novalidate", " novalidate=\"", 2467, "\"", 2480, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 82 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_taikhoan));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 86 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_taikhoan));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 92 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 96 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 102 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_cmnd));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 106 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_cmnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 112 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_dienthoai));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 116 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_dienthoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 122 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 126 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"form-group\">\r\n                            <div class=\"control-label col-md-3 col-sm-3 col-xs-12\">\r\n                                <label>");
#nullable restore
#line 132 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                  Write(Html.DisplayNameFor(model => model.nv_email));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : </label>\r\n                                \r\n                            </div>\r\n                            <div class=\"col-md-6 col-sm-6 col-xs-12\">\r\n                                <label class=\"form-control col-md-7 col-xs-12\" > ");
#nullable restore
#line 136 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                                            Write(Html.DisplayFor(model => model.nv_email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                            </div>
                        </div>

                        <div class=""ln_solid""></div>
                        <div class=""form-group"">
                            <div class=""col-md-6 col-sm-6 col-xs-12 col-md-offset-3"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1d6ee13384bb9e6fa6d869495ef59077b8fa15e311748", async() => {
                WriteLiteral("<i\r\n                      class=\"fa fa-pencil\"></i> Cập Nhật ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 143 "C:\Users\Asus\Desktop\LV_Etourism\LV_DuLichDienTu\Views\NhanViens\Details.cshtml"
                                                       WriteLiteral(Model.nv_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LV_DuLichDienTu.Models.NhanVien> Html { get; private set; }
    }
}
#pragma warning restore 1591
