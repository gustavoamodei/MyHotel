using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    public class ReservaController : Controller
    {
        public IActionResult Index()
        {
            ReservaModel reserva = new ReservaModel();
            ViewBag.ListaReservaAtiva = reserva.ListaReservasAtivas();
            return View();
        }
        [HttpGet]
        public IActionResult CrearReserva()
        {
            ReservaModel data = new ReservaModel();
            ViewBag.ListaAcomodacao= data.ListaAcomodacao();
            return View();
        }

        [HttpPost]
        public IActionResult CrearReserva( ReservaModel reserva)
        {
            
                if (ModelState.IsValid)
                {
                    ReservaModel data = new ReservaModel();
                    ViewBag.ListaAcomodacao = data.ListaAcomodacao();
                    reserva.Insert();
                    return RedirectToAction("Index");
                }
                return View();
           
            
        }



    }
}