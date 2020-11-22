using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAgenda.Web.Models
{
    public class CategoriaCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da categoria.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{5,50}$", ErrorMessage = "Erro. Nome inválido.")]
        [Display(Name = "Informe a Categoria:")] //label
        public string Nome{ get; set; }
    }
}