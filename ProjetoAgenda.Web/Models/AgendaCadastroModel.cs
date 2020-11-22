using ProjetoAgenda.Data.Entities;
using ProjetoAgenda.Data.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgenda.Web.Models
{
    public class AgendaCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o titulo da tarefa.")]
        [Display(Name = "Titulo da Tarefa:")] //label
        public string Titulo { get; set; } //campo

        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        [Display(Name = "Descrição:")] //label
        public string Descricao { get; set; } //campo
        [Required(ErrorMessage = "Por favor, informe a data/hora de inicio da tarefa.")]
        [Display(Name = "Data/Hora de Inicio:")] //label
        public DateTime DataHoraInicio { get; set; } //campo
        [Required(ErrorMessage = "Por favor, informe a data/hora de termino da tarefa.")]
        [Display(Name = "Data/Hora de Término:")] //label
        public DateTime DataHoraFim { get; set; } //campo
        #region Campo de Seleção de Categorias
        [Required(ErrorMessage = "Por favor, selecione a categoria da tarefa.")]
        [Display(Name = "Selecione a Categoria:")] //label
        public int IdCategoria { get; set; } //capturar o valor selecionado

        public List<SelectListItem> ListagemCategorias
        {
            get
            {
                //retornar uma lista com as categorias do banco de dados..
                List<SelectListItem> lista = new List<SelectListItem>();
                CategoriaData d = new CategoriaData();
                foreach (Categoria c in d.FindAll())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = c.IdCategoria.ToString(); //valor do campo
                    item.Text = c.Nome; //texto exibido no campo
                    lista.Add(item); //adicionar o item na lista..
                }
                return lista; //retornar a lista..
            }
        }
        #endregion
    }
}