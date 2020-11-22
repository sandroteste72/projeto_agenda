using FluentNHibernate.Mapping;
using ProjetoAgenda.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda.Data.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario"); 
                              
            Id(u => u.IdUsuario, "IdUsuario").GeneratedBy.Identity();
            Map(u => u.Nome, "Nome").Length(50).Not.Nullable();
            Map(u => u.Login, "Login").Length(20).Not.Nullable().Unique();
            Map(u => u.Senha, "Senha").Length(40).Not.Nullable();
            Map(u => u.DataCadastro, "DataCadastro").Not.Nullable();

            //Relacionamentos...
            HasMany(u => u.Tarefas).KeyColumn("IdUsuario").Inverse();
        }
    }
}
