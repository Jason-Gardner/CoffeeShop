#pragma checksum "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75dc29665add841cffd44c1c6837cc34fb040f2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Profile), @"mvc.1.0.view", @"/Views/Home/Profile.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75dc29665add841cffd44c1c6837cc34fb040f2c", @"/Views/Home/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0280a23aa28fddc99a39f5869bf0f0a5a4076c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
 if (SignInManager.IsSignedIn(User))
{
    AspNetUsers tempUser = JsonSerializer.Deserialize<AspNetUsers>(HttpContextAccessor.HttpContext.Session.GetString("user"));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 style=\"text-align: center\">Profile Information</h1>\r\n");
            WriteLiteral("    <table style=\"padding-bottom: 10px;\" align=\"center\">\r\n        <tr>\r\n            <td>Email: ");
#nullable restore
#line 21 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
                  Write(tempUser.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Phone: ");
#nullable restore
#line 24 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
                  Write(tempUser.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Balance: $");
#nullable restore
#line 27 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
                     Write(String.Format("{0:0.00}", tempUser.Balance));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>\r\n                <input type=\"button\" name=\"order\" value=\"Order\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1012, "\"", 1065, 3);
            WriteAttributeValue("", 1022, "location.href=\'", 1022, 15, true);
#nullable restore
#line 31 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
WriteAttributeValue("", 1037, Url.Action("Order","Home"), 1037, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1064, "\'", 1064, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"button\" name=\"logout\" value=\"Logout\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1136, "\"", 1190, 3);
            WriteAttributeValue("", 1146, "location.href=\'", 1146, 15, true);
#nullable restore
#line 32 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
WriteAttributeValue("", 1161, Url.Action("Logout","Home"), 1161, 28, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1189, "\'", 1189, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"button\" name=\"history\" value=\"History\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1263, "\"", 1318, 3);
            WriteAttributeValue("", 1273, "location.href=\'", 1273, 15, true);
#nullable restore
#line 33 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
WriteAttributeValue("", 1288, Url.Action("History","Home"), 1288, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1317, "\'", 1317, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"button\" name=\"about\" value=\"Item Lookup\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1393, "\"", 1446, 3);
            WriteAttributeValue("", 1403, "location.href=\'", 1403, 15, true);
#nullable restore
#line 34 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
WriteAttributeValue("", 1418, Url.Action("About","Home"), 1418, 27, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1445, "\'", 1445, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n    </table>\r\n");
#nullable restore
#line 38 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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
