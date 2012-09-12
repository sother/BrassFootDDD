using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DDD.ExemploPuro.Framework;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DD.Exemplopuro.Domain.Mappings;
using DDD.Exemplopuro.Domain.Mappings;

namespace DDD.Exemplopuro.Domain
{
    public abstract class BaseRepository
    {
        public const string NHibernateSessionKey = "nhibernate.session.key";

        public static ISessionFactory FACTORY = CreateSessionFactory();
        private static ISession _session;

        public static ISession Session
        {
            get { return _session ?? (_session = FACTORY.OpenSession()); }
        }

        private static object syncObj = 1;

        #region Métodos Genericos para acesso ao DB

        public BaseRepository()
        {
            
        }

        public virtual void Salvar(IAggregateRoot<int> root)
        {
            var transaction = Session.BeginTransaction();
            Session.SaveOrUpdate(root);

            transaction.Commit();
        }

        public virtual void Deletar(IAggregateRoot<int> root)
        {
            var transaction = Session.BeginTransaction();
            Session.Delete(root);
            transaction.Commit();
        }

        public virtual IList<T> Todos<T>()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        public T Obter<T>(int id)
        {
            return Session.Get<T>(id);
        }

        #endregion

        #region Métodos de Sessão e Transação
        public static void CloseTransaction(ITransaction transaction)
        {
            transaction.Dispose();
        }
        public static ISession GetCurrentSession()
        {
            ISession currentSession = null;

            lock (syncObj)
                currentSession = FACTORY.OpenSession();

            return currentSession;
        }
        public static ISessionFactory CreateSessionFactory()
        {
            //return Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c
            //      .Server(@".\SQLEXPRESS")
            //      .Database("ExemploPuro")
            //      .TrustedConnection()
            //    //.Username("sa")
            //    //.Password("123456")))
            //      )).Mappings(m => m.FluentMappings.AddFromAssemblyOf<TimeMap>())
            //      .BuildSessionFactory();

            return Fluently.Configure().Database(
                SQLiteConfiguration.Standard
                .UsingFile("ExemploPuro.db")).Mappings(m => m.FluentMappings.AddFromAssemblyOf<TimeMap>())
                .BuildSessionFactory();
        }

        #endregion

    }
}
