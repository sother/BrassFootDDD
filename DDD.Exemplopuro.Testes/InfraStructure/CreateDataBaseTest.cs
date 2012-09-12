using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using DDD.Exemplopuro.Domain.Mappings;
using System.IO;
using NHibernate;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Testes.InfraStructure
{
    [TestFixture]
    public class CreateDataBaseTest
    {
        [Test]
       [Ignore]
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



        //[Test]
        //[Ignore]
        //public void Criar_Banco_De_Dados_Por_Modelo()
        //{
        //    try
        //    {
        //        Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c
        //       .Is(@"Data Source=.\SQLEXPRESS;Initial Catalog=ExemploPuro;Integrated Security=True")
        //        )).Mappings(m => m.FluentMappings.AddFromAssemblyOf<TimeMap>())
        //        .ExposeConfiguration(BuildSchema).BuildSessionFactory();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        //private void BuildSchema(Configuration config)
        //{
        //    new SchemaExport(config)
        //        .Create(false, true);
        //}
    }
}
