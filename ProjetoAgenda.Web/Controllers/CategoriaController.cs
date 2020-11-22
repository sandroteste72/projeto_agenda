using ProjetoAgenda.Data.Entities;
using ProjetoAgenda.Data.Persistence;
using ProjetoAgenda.Web.Models;
using System;
using System.Web.Mvc;

namespace ProjetoAgenda.Web.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(CategoriaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Categoria c = new Categoria() //entidade
                    {
                        Nome = model.Nome
                    };

                    CategoriaData cd = new CategoriaData(); //persistencia
                    cd.Insert(c); //gravando na base de dados...
                    ViewBag.Mensagem = "Categoria " + c.Nome + ", cadastrada com sucesso.";
                    ModelState.Clear(); //limpar o conteudo do formulario
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro"); //page_load
        }
    }
}