using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                //formulario.HttpContextAccessor = HttpContextAccessor;
                cliente.insert();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public JsonResult getCidades(int estado)

        {

           ClienteModel objcidades = new ClienteModel();
           var lista=  objcidades.populaCidades(estado);
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());
            
        }


        [HttpGet]
        public JsonResult getEstados()

        {

            ClienteModel objestadoss = new ClienteModel();
            var lista = objestadoss.populaEstados();
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());

        }


    }
}