using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Mocks;
using NUnit.Framework;
using DDD.Exemplopuro.InfraStructure;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;
using DDD.Exemplopuro.Domain.Mappings;

namespace DDD.Exemplopuro.Testes
{
    public abstract class TesteBase
    {
        private TransactionManagerFluent transaction;
        private MockRepository repository;
        protected MockRepository Repository
        {
            get
            {
                return repository;

            }
        }

        [SetUp]
        protected virtual void SetUp()
        {
            Criar_Banco_De_Dados_Por_Modelo();

            repository = new MockRepository();

            transaction = new TransactionManagerFluent();

            transaction.Initialize();
        }

        public void Criar_Banco_De_Dados_Por_Modelo()
        {
            try
            {
                Fluently.Configure().Database(
                SQLiteConfiguration.Standard
                .UsingFile("ExemploPuro.db")).Mappings(m => m.FluentMappings.AddFromAssemblyOf<TimeMap>())
                .ExposeConfiguration(BuildSchema).BuildSessionFactory();

            }
            catch (Exception)
            {

                throw;
            }

        }


        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("ExemploPuro.db"))
                File.Delete("ExemploPuro.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }


        [TearDown]
        protected virtual void TearDown()
        {
            transaction.VoteRollBack();
            transaction.Dispose();
        }

    }
}
