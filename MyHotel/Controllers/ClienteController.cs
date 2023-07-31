﻿using System;
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
            ClienteModel cliente = new ClienteModel();
            ViewBag.ListaClientes = cliente.ListarClientes();

            return View();
        }
      

        [HttpGet]
        public IActionResult CrearCliente(int ?id)
        {
            if (id != null)
            {
                ClienteModel cliente = new ClienteModel();
                ViewBag.RecuperaCliente = cliente.CarregarCliente(id);
              
            }
            return View();
        }

        [HttpPost]
        public IActionResult CrearCliente(ClienteModel cliente)
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
        public JsonResult GetCidades(int estado)

        {

           ClienteModel objcidades = new ClienteModel();
           var lista=  objcidades.PopulaCidades(estado);
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());
            
        }


        [HttpGet]
        public JsonResult GetEstados()

        {

            ClienteModel objestadoss = new ClienteModel();
            var lista = objestadoss.PopulaEstados();
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());

        }
        [HttpGet]
        public JsonResult Excluir(string id)
        {
            ClienteModel objcliente = new ClienteModel();
            var lista = objcliente.ExcluirCliente(id);
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult tb()

        {

            ClienteModel objestadoss = new ClienteModel();
            var lista = objestadoss.Teste();
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());

        }

    }
}