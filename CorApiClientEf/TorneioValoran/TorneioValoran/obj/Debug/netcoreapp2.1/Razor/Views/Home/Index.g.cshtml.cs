#pragma checksum "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "458043133f6929c060142546e86c3dc114166fd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\_ViewImports.cshtml"
using TorneioValoran;

#line default
#line hidden
#line 2 "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\_ViewImports.cshtml"
using TorneioValoran.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"458043133f6929c060142546e86c3dc114166fd4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c766480451d5382210093115f6790539f9028eae", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 131, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <h2>Criar Time</h2>\r\n        <button type=\"button\" class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 176, "\"", 232, 3);
            WriteAttributeValue("", 186, "window.location=\'", 186, 17, true);
#line 8 "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\Home\Index.cshtml"
WriteAttributeValue("", 203, Url.Action("Index", "Team"), 203, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 231, "\'", 231, 1, true);
            EndWriteAttribute();
            BeginContext(233, 187, true);
            WriteLiteral(" >Criar</button>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <h2>Iniciar Partida</h2>\r\n        <button type=\"button\" class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 420, "\"", 477, 3);
            WriteAttributeValue("", 430, "window.location=\'", 430, 17, true);
#line 15 "C:\Users\rafvini\Documents\teste-master\teste-master\TorneioValoran\TorneioValoran\Views\Home\Index.cshtml"
WriteAttributeValue("", 447, Url.Action("Index", "Group"), 447, 29, false);

#line default
#line hidden
            WriteAttributeValue("", 476, "\'", 476, 1, true);
            EndWriteAttribute();
            BeginContext(478, 37, true);
            WriteLiteral(">Jogar</button>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
