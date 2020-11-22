using ProjetoAgenda.Data.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAgenda.Web.Validators
{
    public class LoginDisponivel : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //value -> representa o valor do elemento que está sendo validado
            string Login = (string)value;
            //acessar a base de dados...
            UsuarioData d = new UsuarioData();
            return !d.HasLogin(Login);
        }
    }
}