#pragma checksum "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2007bbddefc5cbf57e5420f23583f1bcf1a2666a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reserva_ReservaCanceladas), @"mvc.1.0.view", @"/Views/Reserva/ReservaCanceladas.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reserva/ReservaCanceladas.cshtml", typeof(AspNetCore.Views_Reserva_ReservaCanceladas))]
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
#line 1 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\_ViewImports.cshtml"
using MyHotel;

#line default
#line hidden
#line 2 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\_ViewImports.cshtml"
using MyHotel.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2007bbddefc5cbf57e5420f23583f1bcf1a2666a", @"/Views/Reserva/ReservaCanceladas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b3c21a387bd7be247f92655a9e5ddca6db5620a", @"/Views/_ViewImports.cshtml")]
    public class Views_Reserva_ReservaCanceladas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(41, 452, true);
            WriteLiteral(@"
<br />
<br />
<br />
<h3 class=""text-center"">Reservas Canceladas</h3>

<br />
<table id=""table"" class=""table table-bordered"">
    <thead>
        <tr>
            <th>ID</th>
            <th>Id Cliente</th>
            <th>Cliente</th>
            <th>Acomodação</th>
            <th>N° Acomodação</th>
            <th>Entrada</th>
            <th>Saida</th>
            <th>Status</th>
        </tr>
    </thead>
    <tbody>


");
            EndContext();
#line 27 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
          
            foreach (var item in (List<ReservaModel>)ViewBag.ListaReservaAtiva)
            {


#line default
#line hidden
            BeginContext(603, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(650, 18, false);
#line 32 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(668, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(700, 26, false);
#line 33 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Cliente_id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(726, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(758, 17, false);
#line 34 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Nome_Cliente);

#line default
#line hidden
            EndContext();
            BeginContext(775, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(807, 16, false);
#line 35 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Nome_quarto);

#line default
#line hidden
            EndContext();
            BeginContext(823, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(855, 18, false);
#line 36 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Numero_quarto);

#line default
#line hidden
            EndContext();
            BeginContext(873, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(905, 23, false);
#line 37 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Entrada.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(928, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(960, 21, false);
#line 38 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Saida.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(981, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1013, 22, false);
#line 39 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"
                   Write(item.Status.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1035, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 41 "C:\Users\gustavo\source\repos\hotelMananger\MyHotel\Views\Reserva\ReservaCanceladas.cshtml"

            }
        

#line default
#line hidden
            BeginContext(1093, 28, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1160, 1058, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#table').DataTable(
                {

                    ""oLanguage"": {
                        ""sProcessing"": ""Processando..."",
                        ""sLengthMenu"": ""Mostrar _MENU_ registros"",
                        ""sZeroRecords"": ""Não foram encontrados resultados"",
                        ""sInfo"": ""Mostrando de _START_ até _END_ de _TOTAL_ registros"",
                        ""sInfoEmpty"": ""Mostrando de 0 até 0 de 0 registros"",
                        ""sInfoFiltered"": """",
                        ""sInfoPostFix"": """",
                        ""sSearch"": ""Buscar:"",
                        ""sUrl"": """",
                        ""oPaginate"": {
                            ""sFirst"": ""Primeiro"",
                            ""sPrevious"": ""Anterior"",
                            ""sNext"": ""Seguinte"",
                            ""sLast"": ""Último""
                        }
                    }
                }


            );");
                WriteLiteral("\r\n        });\r\n    </script>\r\n    ");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591