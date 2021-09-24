using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web02LojadeJogos.Models;
using Web02LojadeJogos.Repositorio;

namespace Web02LojadeJogos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cadastrar()
        {
            var cliente = new Cliente();
            return View(cliente);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ac.CadastrarCliente(cliente);
                    return RedirectToAction("Listar");
                }
                return View(cliente);
            }
            catch
            {
                return RedirectToAction("Cadastrar");
            }
        }
        public ActionResult Listar()
        {
            var Exibir = new Acoes();
            var Todos = Exibir.BuscarTodosClientes();
            return View(Todos);
        }
    }
}