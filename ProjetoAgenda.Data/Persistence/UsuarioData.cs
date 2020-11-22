using NHibernate;
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
    public class UsuarioData : GenericData<Usuario>
    {        
        public bool HasLogin(string Login)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //SQL -> select count(*) from Usuario where Login = ?
                var query = from u in s.Query<Usuario>()
                            where u.Login.Equals(Login)
                            select u;
                //retornar a quantidade obtida...
                return query.Count() > 0;
            }
        }

        public Usuario Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //SQL -> select * from Usuario where Login=? and Senha=?
                var query = from u in s.Query<Usuario>()
                            where u.Login.Equals(Login)
                            && u.Senha.Equals(Senha)
                            select u;
                //retornar o primeiro registro encontrado
                return query.FirstOrDefault();
            }
        }
    }
}
