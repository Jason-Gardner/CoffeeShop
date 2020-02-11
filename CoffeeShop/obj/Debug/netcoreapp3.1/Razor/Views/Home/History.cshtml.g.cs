#pragma checksum "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ec3ee7aa226b5dde6ed93b7aa39122f15a3a6c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_History), @"mvc.1.0.view", @"/Views/Home/History.cshtml")]
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
#line 1 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ec3ee7aa226b5dde6ed93b7aa39122f15a3a6c5", @"/Views/Home/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0280a23aa28fddc99a39f5869bf0f0a5a4076c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopDBContext>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
  
    ViewData["Title"] = "Order History";
    Layout = "~/Views/Shared/_Layout.cshtml";
    Client tempUser = JsonSerializer.Deserialize<Client>(HttpContextAccessor.HttpContext.Session.GetString("user"));
    List<Orders> orderHistory = JsonSerializer.Deserialize<List<Orders>>(HttpContextAccessor.HttpContext.Session.GetString("orders"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1><i>History</i></h1>\r\n<table style=\"width: 75%;\" align:center>\r\n");
#nullable restore
#line 16 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
     foreach (var order in orderHistory)
    {
        foreach (var item in Model.Inventory)
        {
            if (item.ProductId == order.ItemId)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 24 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
                   Write(order.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 27 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
                   Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <b>Order Total: $");
#nullable restore
#line 30 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
                                    Write(String.Format("{0:0.00}", item.UnitPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Jason Gardner\source\repos\CoffeeShop\CoffeeShop\Views\Home\History.cshtml"
            }
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopDBContext> Html { get; private set; }
    }
}
#pragma warning restore 1591
