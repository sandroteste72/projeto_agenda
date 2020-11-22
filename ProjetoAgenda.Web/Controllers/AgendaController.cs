using ProjetoAgenda.Data.Entities;
using ProjetoAgenda.Data.Persistence;
using ProjetoAgenda.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgenda.Web.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View(new AgendaCadastroModel());
        }
        // GET: /Agenda/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTarefa(AgendaCadastroModel model)
        {
            if (ModelState.IsValid) //regras de validação estao ok?
            {
                try
                {
                    Tarefa t = new Tarefa() //entidade
                    {
                        Titulo = model.Titulo,
                        Descricao = model.Descricao,
                        DataHoraInicio = model.DataHoraInicio,
                        DataHoraFim = model.DataHoraFim,
                        Categoria = new CategoriaData().Find(model.IdCategoria),
                        Usuario = (Usuario)Session["usuariologado"]
                    }; 
                    TarefaData d = new TarefaData(); //persistencia
                    d.Insert(t); //gravando..
                    ViewBag.Mensagem = "Tarefa " + t.Titulo + ", cadastrado com sucesso.";
                    ModelState.Clear(); //limpar o conteudo da model..
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro", new AgendaCadastroModel()); //nome da view..
        }

        [HttpPost]
        public ActionResult ConsultarTarefas(AgendaConsultaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TarefaData d = new TarefaData(); //persistencia...
                    Usuario u = (Usuario)Session["usuariologado"];
                    model.ListagemTarefas = d.FindAll(model.DataIni, model.DataFim, u.IdUsuario);
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Consulta", model);
        }

        [HttpGet]
        public ActionResult ExcluirTarefa(int id)
        {
            try
            {
                TarefaData d = new TarefaData();
                Tarefa t = d.Find(id); //buscando 1 tarefa pelo id..
                d.Delete(t); //excluindo a tarefa...
                ViewBag.Mensagem = "Tarefa excluida com sucesso.";
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("Consulta");
        }
    }
}