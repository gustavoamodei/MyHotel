using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    public class CardapioController : Controller
    {
        public IActionResult Index()
        {
            CardapioModel cardapio = new CardapioModel();
            ViewBag.ListaCardapio = cardapio.ListarCardapio();
            return View();
        }


        [HttpGet]
        public IActionResult CrearCardapio(int? id)
        {

            if (id != null)
            {
                CardapioModel cardapio = new CardapioModel();
                cardapio = new CardapioModel();
                ViewBag.RecuperaCardapio = cardapio.CarregarCardapio(id);

            }

            return View();
        }


        [HttpPost]
        public IActionResult CrearCardapio(CardapioModel cliente)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                cliente.Insert();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Excluir(string id)
        {
            CardapioModel obj = new CardapioModel();
            obj.ExcluirCardapio(id);
            return RedirectToAction("Index");
        }

    }
}
