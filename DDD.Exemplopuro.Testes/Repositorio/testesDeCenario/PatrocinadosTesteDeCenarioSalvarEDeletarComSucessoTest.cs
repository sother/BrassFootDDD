using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain;
using DDD.Exemplopuro.Testes.InfraStructure;

namespace DDD.Exemplopuro.Testes.Repositorio
{
    [TestFixture]
    public class PatrocinadosTesteDeCenarioSalvarEDeletarComSucessoTest : PersistenceTestBase
    {
        public Patrocinados Patrocinados { get; set; }
        public Patrocinado Patrocinado { get; set; }

        [SetUp]
        public void SetUp_criar_time_no_banco()
        {
            criar_time_com_sucesso();
        }

        [TearDown]
        protected void  TearDown()
        {
            excluir_time_com_sucesso();
        }

        private void excluir_time_com_sucesso()
        {
            Patrocinados.Deletar(Patrocinado);
        }

        private void criar_time_com_sucesso()
        {
            Patrocinados = new Patrocinados();
            Patrocinados.InformarSession(base.Session);
            Patrocinado = new Time("barcelona");
            Patrocinados.Salvar(Patrocinado);
        }

        [Test]
        public void deve_ter_nome_igual_a_barcelona()
        {
            Assert.AreEqual(Patrocinado.Nome, "barcelona");
        }

        [Test]
        public void deve_ter_id_maior_que_zero()
        {
            Assert.Greater(Patrocinado.Id, default(int));
        }
    }
}
