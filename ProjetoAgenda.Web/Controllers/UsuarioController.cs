using ProjetoAgenda.Data.Entities;
using ProjetoAgenda.Data.Persistence;
using ProjetoAgenda.Util;
using ProjetoAgenda.Web.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoAgenda.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AutenticarUsuario(UsuarioLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioData d = new UsuarioData(); //persistencia...
                    Usuario u = d.Authenticate(model.Login,
                    Criptografia.GetMD5Hash(model.Senha));
                    if (u != null) //usuario foi encontrado....
                    {
                        //Gerar um Ticket de Acesso para o usuario...
                        FormsAuthentication.SetAuthCookie(u.Login, false);
                        //Armazenar o objeto Usuario em sessão...
                        Session.Add("usuariologado", u);
                        //redirecionar para a Agenda...
                        return RedirectToAction("Index", "Agenda");
                    }
                    else //usuario nao encontrado...
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Login");
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario() //entidade
                    {
                        Nome = model.Nome,
                        Login = model.Login,
                        Senha = Criptografia.GetMD5Hash(model.Senha),
                        DataCadastro = DateTime.Now
                    }; 

                    UsuarioData d = new UsuarioData(); //persistencia
                    d.Insert(u); //gravando na base de dados...
                    ViewBag.Mensagem = "Usuario " + u.Nome + ", cadastrado com sucesso.";
                    ModelState.Clear(); //limpar o conteudo do formulario
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro"); //page_load
        }

        [Authorize]
        public ActionResult Logout()
        {
            //Passo 1) Remover o ticket de acesso criado..
            FormsAuthentication.SignOut();
            //Passo 2) Remover o usuario logado da sessão..
            Session.Remove("usuariologado");
            Session.Abandon(); //invalida a sessão..
            return View("Login");
        }
    }
}