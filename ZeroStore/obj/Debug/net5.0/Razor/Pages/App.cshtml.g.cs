#pragma checksum "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cffef6b34131b606178d253a6dff81e5a1a5f134"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZeroStore.Pages.Pages_App), @"mvc.1.0.razor-page", @"/Pages/App.cshtml")]
namespace ZeroStore.Pages
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
#line 1 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\_ViewImports.cshtml"
using ZeroStore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cffef6b34131b606178d253a6dff81e5a1a5f134", @"/Pages/App.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f184bc7fcb36f372b16c0c48b5206c13e3dfd326", @"/Pages/_ViewImports.cshtml")]
    public class Pages_App : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
  
	ViewData["Title"] = Model._App.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\t<h1>");
#nullable restore
#line 8 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
   Write(Model._App.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1><br>\r\n</div>\r\n<table class=\"table\">\r\n\t<tbody>\r\n\t\t<tr>\r\n\t\t\t<td rowspan=\"3\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cffef6b34131b606178d253a6dff81e5a1a5f1343404", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 225, "~/MyImages/", 225, 11, true);
#nullable restore
#line 13 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
AddHtmlAttributeValue("", 236, Model._App.Picture, 236, 19, false);

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
            WriteLiteral("</td>\r\n\t\t\t<td>Разработчик: ");
#nullable restore
#line 14 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
                        Write(Model.DeveloperName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>Жанр: ");
#nullable restore
#line 17 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
                 Write(Model._App.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>Цена: ");
#nullable restore
#line 20 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
                 Write(Model._App.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t</tr>\r\n\t</tbody>\r\n</table>\r\n<p>\r\n\tОписание: <br>\r\n\t");
#nullable restore
#line 26 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
Write(Model._App.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<br>\r\n<p>\r\n\tDLC:<br>\r\n\t<ol>\r\n");
#nullable restore
#line 32 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
         foreach (var dlc in Model.DLCs)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<li>");
#nullable restore
#line 34 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
           Write(dlc.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
                     Write(dlc.Cost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" руб</li>\r\n");
#nullable restore
#line 35 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</ol>\r\n</p>\r\n<br>\r\n<p>\r\n\tКомментари: <br>\r\n");
#nullable restore
#line 41 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
     foreach (var comment in Model.Comments)
	{
		

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
   Write(comment);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n");
#nullable restore
#line 44 "C:\Users\мэлт\Source\Repos\Bars\ZeroStore\ZeroStore\Pages\App.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ZeroStore.Pages.AppModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZeroStore.Pages.AppModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ZeroStore.Pages.AppModel>)PageContext?.ViewData;
        public ZeroStore.Pages.AppModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591