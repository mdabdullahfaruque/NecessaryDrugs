#pragma checksum "D:\Project\Necessary Drugs\NecessaryDrugs\NecessaryDrugs.Web\Areas\Admin\Views\Stock\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8c0d88e80d8162c1feecfffec359a234bd66f9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Stock_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Stock/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8c0d88e80d8162c1feecfffec359a234bd66f9d", @"/Areas/Admin/Views/Stock/Index.cshtml")]
    public class Areas_Admin_Views_Stock_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NecessaryDrugs.Web.Areas.Admin.Models.StockViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\Necessary Drugs\NecessaryDrugs\NecessaryDrugs.Web\Areas\Admin\Views\Stock\Index.cshtml"
   ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-12\" id=\"view-all\">\r\n    ");
#nullable restore
#line 5 "D:\Project\Necessary Drugs\NecessaryDrugs\NecessaryDrugs.Web\Areas\Admin\Views\Stock\Index.cshtml"
Write(await Html.PartialAsync("_ViewAll", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        jQueryAjaxDelete = form => {
            if (confirm('Are you sure to delete this record ?')) {
                try {
                    $.ajax({
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            $('#view-all').html(res.html);
                        },
                        error: function (err) {
                            console.log(err)
                        }
                    })
                } catch (ex) {
                    console.log(ex)
                }
            }

            //prevent default form submit event
            return false;
        }

    </script>
");
#nullable restore
#line 36 "D:\Project\Necessary Drugs\NecessaryDrugs\NecessaryDrugs.Web\Areas\Admin\Views\Stock\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NecessaryDrugs.Web.Areas.Admin.Models.StockViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591