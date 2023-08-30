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
        public IActionResult ReservaCanceladas()
        {
            ReservaModel reserva = new ReservaModel();
            ViewBag.ListaReservaAtiva = reserva.ListaReservasCanceladas();
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
            
               
                    ReservaModel data = new ReservaModel();
                    ViewBag.ListaAcomodacao = data.ListaAcomodacao();

                    string  cliente_valido =  data.Verifica_Cliente_Valido(reserva.Cliente_id);
                    string reserva_valida = data.Verificar_Autorizacao_reserva(reserva.Cliente_id);
                    int result = DateTime.Compare(DateTime.Parse(reserva.Entrada), DateTime.Parse(reserva.Saida));

            if (result == 1)
            {
                ViewData["erro"] = "Data de entrada deve ser anterior da data da saida";
                return View();
            }
            if (result == 0)
            {
                ViewData["erro"] = "as datas da entrada e de saida não pódem ser iguais";
                return View();
            }
            if (cliente_valido.Equals("Cliente não existe ou não está cadastrado"))
            {
                ViewData["erro"] = cliente_valido;
                return View();
            }
            if (reserva_valida.Equals("Existe uma reserva em andamento para este cliente"))
            {
                ViewData["erro"] = reserva_valida;
                return View();
                    
            }
            try
            {
                reserva.Insert();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["erro"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Cancelar(int id)
        {
            ReservaModel obj = new ReservaModel();
            obj.CancelarReserva(id);
            return RedirectToAction("Index");
        }



    }
}