using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web02LojadeJogos.Models;
using Web02LojadeJogos.Repositorio;

namespace Web02LojadeJogos.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Cadastrar()
        {
            var funcionario = new Funcionario();
            return View(funcionario);
        }
        Acoes ac = new Acoes();

        [HttpPost]
        public ActionResult Listar(Funcionario funcionario)
        {
            ac.CadastrarFuncionario(funcionario);
            var Exibir = new Acoes();
            var Todos = Exibir.BuscarTodosFuncionarios();
            return View(Todos);
        }
    }
}