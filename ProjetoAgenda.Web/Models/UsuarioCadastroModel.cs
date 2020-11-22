using ProjetoAgenda.Web.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAgenda.Web.Models
{
    public class UsuarioCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuario.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$", ErrorMessage = "Erro. Nome inválido.")]
        [Display(Name = "Informe seu Nome:")] //label
        public string Nome { get; set; } //campo

        [Required(ErrorMessage = "Por favor, informe o login do usuario.")]
        [RegularExpression("^[a-z0-9]{6,20}$", ErrorMessage = "Erro. Login inválido.")]
        [LoginDisponivel(ErrorMessage = "Erro. Este login encontra-se indisponivel.Tente outro.")]
        [Display(Name = "Login de Acesso:")] //label
        public string Login { get; set; } //campo

        [Required(ErrorMessage = "Por favor, informe a senha do usuario.")]
        [RegularExpression("^[A-Za-z0-9@]{6,20}$", ErrorMessage = "Erro. Senha inválida.")]
        [Display(Name = "Senha de Acesso:")] //label
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a senha do usuario.")]
        [Compare("Senha", ErrorMessage = "Erro. Confirme sua Senha corretamente.")]
        [Display(Name = "Confirme sua Senha:")] //label
        public string SenhaConfirm { get; set; } //campo
    }
}