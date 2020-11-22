using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ProjetoAgenda.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda.Data.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory factory;
        public static ISessionFactory GetSessionFactory()
        {
            if (factory == null)
            {
                factory = Fluently.Configure().Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        ConfigurationManager.ConnectionStrings["banco"].ConnectionString
                        )
                    ).Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>()).BuildSessionFactory();
            }
            return factory;
        }
    }
}
