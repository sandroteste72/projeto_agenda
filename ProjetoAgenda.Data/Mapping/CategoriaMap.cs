using FluentNHibernate.Mapping;
using ProjetoAgenda.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda.Data.Mapping
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("Categoria"); //nome da tabela..
                                //chave primaria..
            Id(c => c.IdCategoria, "IdCategoria").GeneratedBy.Identity();
            //demais atributos...
            Map(c => c.Nome, "Nome").Length(50).Not.Nullable();
            //Relacionamentos...
            HasMany(c => c.Tarefas).KeyColumn("IdCategoria").Inverse();
        }
    }
}
