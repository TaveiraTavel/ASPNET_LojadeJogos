using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web02LojadeJogos.Models;

namespace Web02LojadeJogos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Index(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                return View("Listar", cliente);
            }
            return View(cliente);
        }
        public ActionResult Listar(Cliente cliente)
        {
            return View(cliente);
        }
    }
}