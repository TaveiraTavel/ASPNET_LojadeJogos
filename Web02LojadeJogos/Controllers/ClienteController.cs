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
        public ActionResult Mensagem(Cliente cliente)
        {
            ac.CadastrarCliente(cliente);
            return View(cliente);
        }
        public ActionResult Listar(Cliente cliente)
        {
            var Exibir = new Acoes();
            var Todos = Exibir.BuscarTodosClientes();
            return View(Todos);
        }
    }
}