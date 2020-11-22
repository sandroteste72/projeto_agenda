using ProjetoAgenda.Data.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAgenda.Web.Models
{
    public class AgendaConsultaModel
    {
        [Required(ErrorMessage = "Por favor, informe a data de inicio.")]
        [Display(Name = "Data de Inicio")]
        public DateTime DataIni { get; set; }
        [Required(ErrorMessage = "Por favor, informe a data de termino.")]
        [Display(Name = "Data de Termino")]
        public DateTime DataFim { get; set; }
        //propriedade para exibir o resultado da pesquisa...
        public List<TarefaDto> ListagemTarefas { get; set; }
    }
}