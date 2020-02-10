#pragma checksum "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "798c001ecf5bbea1c5a67cc1dde3c9b990e4a28f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Review), @"mvc.1.0.view", @"/Views/Home/Review.cshtml")]
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
#line 1 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\_ViewImports.cshtml"
using CoffeeShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\_ViewImports.cshtml"
using CoffeeShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"798c001ecf5bbea1c5a67cc1dde3c9b990e4a28f", @"/Views/Home/Review.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0280a23aa28fddc99a39f5869bf0f0a5a4076c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Review : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Inventory>
    {
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
#nullable restore
#line 1 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml"
  
    ViewData["Title"] = "Review";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Review Order</h1>\r\n\r\n<p>You bought ");
#nullable restore
#line 10 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml"
         Write(Model.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" for $");
#nullable restore
#line 10 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml"
                                 Write(String.Format("{0:0.00}", Model.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(".</p>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "798c001ecf5bbea1c5a67cc1dde3c9b990e4a28f4087", async() => {
                WriteLiteral("\r\n    <input type=\"button\" name=\"order\" value=\"Order More\"");
                BeginWriteAttribute("onclick", " onclick=\"", 290, "\"", 343, 3);
                WriteAttributeValue("", 300, "location.href=\'", 300, 15, true);
#nullable restore
#line 13 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml"
WriteAttributeValue("", 315, Url.Action("Order","Home"), 315, 27, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 342, "\'", 342, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input type=\"button\" name=\"logout\" value=\"Logout\"");
                BeginWriteAttribute("onclick", " onclick=\"", 402, "\"", 456, 3);
                WriteAttributeValue("", 412, "location.href=\'", 412, 15, true);
#nullable restore
#line 14 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Review.cshtml"
WriteAttributeValue("", 427, Url.Action("Logout","Home"), 427, 28, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 455, "\'", 455, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Inventory> Html { get; private set; }
    }
}
#pragma warning restore 1591
