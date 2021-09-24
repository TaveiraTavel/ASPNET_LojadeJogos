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
        public ActionResult Cadastrar()
        {
            var jogo = new Jogo();
            return View(jogo);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult Cadastrar(Jogo jogo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ac.CadastrarJogo(jogo);
                    return RedirectToAction("Listar");
                }
                return View(jogo);
            }
            catch
            {
                return RedirectToAction("Cadastrar");
            }   
        }
        public ActionResult Listar()
        {
            var Exibir = new Acoes();
            var Todos = Exibir.BuscarTodosJogos();
            return View(Todos);
        }
    }
}