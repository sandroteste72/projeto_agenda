using NHibernate;
using ProjetoAgenda.Data.Dto;
using ProjetoAgenda.Data.Entities;
using ProjetoAgenda.Data.Generics;
using ProjetoAgenda.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda.Data.Persistence
{
    public class TarefaData : GenericData<Tarefa>
    {
        public List<TarefaDto> FindAll(DateTime DataIni, DateTime DataFim, int IdUsuario)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from t in s.Query<Tarefa>()
                            where t.DataHoraInicio >= DataIni &&
                            t.DataHoraInicio <= DataFim &&
                            t.Usuario.IdUsuario == IdUsuario
                            orderby t.DataHoraInicio ascending
                            select t;
                List<TarefaDto> lista = new List<TarefaDto>();
                foreach (var t in query.ToList())
                {
                    lista.Add(
                    new TarefaDto()
                    {
                        Codigo = t.IdTarefa,
                        Titulo = t.Titulo,
                        Descricao = t.Descricao,
                        DataHoraInicio = t.DataHoraInicio,
                        DataHoraFim = t.DataHoraFim,
                        Categoria = t.Categoria.Nome,
                        Usuario = t.Usuario.Nome
                    }
                    );
                }
                return lista;
            }
        }
    }
}
