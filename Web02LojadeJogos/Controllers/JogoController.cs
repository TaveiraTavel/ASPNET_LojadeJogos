using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web02LojadeJogos.Models;

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

        [HttpPost]
        public ActionResult Index(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                return View("Listar", jogo);
            }
            return View(jogo);
        }
        public ActionResult Listar(Jogo jogo)
        {
            return View(jogo);
        }
    }
}