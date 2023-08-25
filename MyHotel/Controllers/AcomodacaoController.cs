using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    public class AcomodacaoController : Controller
    {
        public IActionResult Index()
        {
            AcomodacaoModel acomodacao = new AcomodacaoModel();
            ViewBag.ListaAcomodacao = acomodacao.ListarAcomodacao();
            return View();
        }

        [HttpPost]
        public IActionResult CrearAcomodacao(AcomodacaoModel acomodacao)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                acomodacao.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult CrearAcomodacao(int? id)
        {

            if (id != null)
            {
                AcomodacaoModel acomodacao = new AcomodacaoModel();
                ViewBag.RecuperaAcomodacao = acomodacao.CarregarAcomodacao(id) ;

            }

            return View();
        }


        [HttpPost]
        public IActionResult Excluir(string id)
        {
            AcomodacaoModel obj = new AcomodacaoModel();
            obj.ExcluirAcomodacao(id);
            return RedirectToAction("Index");
        }
    }
}