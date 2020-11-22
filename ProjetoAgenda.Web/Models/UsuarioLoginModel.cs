using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAgenda.Web.Models
{
    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        [Display(Name = "Informe seu Login:")] //label
        public string Login { get; set; } //campo
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        [Display(Name = "Informe sua Senha:")] //label
        public string Senha { get; set; } //campo
    }
}