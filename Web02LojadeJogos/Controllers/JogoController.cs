using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web02LojadeJogos.Models;
using Web02LojadeJogos.Repositorio;

namespace Web02LojadeJogos.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        public ActionResult Index()
        {
            var jogo = new Jogo();
            return View(jogo);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult Index(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                return View("Listar", jogo);
            }
            return View(jogo);
        }
        public ActionResult Listar()
        {
            var Exibir = new Acoes();
            var Todos = Exibir.BuscarTodosJogos();
            return View(Todos);
        }
    }
}