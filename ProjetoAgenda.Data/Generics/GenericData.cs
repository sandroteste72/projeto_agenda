﻿using NHibernate;
using ProjetoAgenda.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgenda.Data.Generics
{
    public abstract class GenericData<T> where T : class
    {
        public void Insert(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(obj);
                t.Commit();
            }
        }

        public void Delete(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(obj);
                t.Commit();
            }
        }

        public void Update(T obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Update(obj);
                t.Commit();
            }
        }

        public T Find(int Id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return (T)s.Get(typeof(T), Id);
            }
        }

        public ICollection<T> FindAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //LINQ - Language Integrated Query
                var query = from obj in s.Query<T>()
                            select obj;
                //retornar os dados...
                return query.ToList();
            }
        }
    }
}
