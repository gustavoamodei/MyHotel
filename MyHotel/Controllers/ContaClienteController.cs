using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Models;

namespace MyHotel.Controllers
{
    public class ContaClienteController : Controller
    {
        public IActionResult ListaContas()
        {
            ContaClienteModel data = new ContaClienteModel();
            ViewBag.listaContas = data.ListaContaCliente();
            return View();
        }


        [HttpGet]
        public JsonResult GetAlimentos()

        {

            ContaClienteModel alimento = new ContaClienteModel();
            var lista = alimento.PopulaAlimento();
            return Json(lista, new Newtonsoft.Json.JsonSerializerSettings());

        }

        [HttpPost]
     
        public IActionResult AddItem(string conta_id, int alimento_id, string alimento_valor)
        {

            ContaClienteModel item = new ContaClienteModel();
            item.InsertItem(conta_id, alimento_id, alimento_valor);
            return RedirectToAction("ListaContas");

        }
        [HttpGet]
        public IActionResult Checkout(int id)
        {
            ContaClienteModel contaHospedagem = new ContaClienteModel();
            ViewBag.LCH = contaHospedagem.ListaContaHospedage(id);
            ViewBag.LCA = contaHospedagem.listaContaAlimento(id);
            ViewBag.TPED = contaHospedagem.Totalped(id);
            return View();
        }

        [HttpPost]
        public IActionResult FinalizaHospedagem(int id_quarto)
        {
            ContaClienteModel finaliza = new ContaClienteModel();
            finaliza.FinalizarConta(id_quarto);
           return RedirectToAction("ListaContas");
        }
        

        
    }
}

