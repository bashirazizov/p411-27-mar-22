#pragma checksum "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff104ac6b1e72ae17f4d424f09d20af319c456e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\_ViewImports.cshtml"
using eshop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\_ViewImports.cshtml"
using eshop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\_ViewImports.cshtml"
using eshop.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff104ac6b1e72ae17f4d424f09d20af319c456e5", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44dafa5bafdf9a5fbc06f30e835540fba5a7f809", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""d-sm-flex align-items-center justify-content-between mb-4"">
    <h1 class=""h3 mb-0 text-gray-800"">Dashboard</h1>
</div>
<div class=""row"">
    <div class=""col-xl-3 col-md-6 mb-4"">
        <div class=""card border-left-primary shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                            Users
                        </div>
                        <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 15 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                       Write(Model.UserCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fas fa-user fa-2x text-gray-300""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6 mb-4"">
        <div class=""card border-left-warning shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                            Categories
                        </div>
                        <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 32 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                       Write(Model.CategoryCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fas fa-box fa-2x text-gray-300""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-xl-3 col-md-6 mb-4"">
        <div class=""card border-left-warning shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                            SubCategories
                        </div>
                        <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 49 "C:\Users\Bashir Azizov\Desktop\p411\p411-27-mar-22\eshop\eshop\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                       Write(Model.SubcategoryCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fas fa-box fa-2x text-gray-300""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591