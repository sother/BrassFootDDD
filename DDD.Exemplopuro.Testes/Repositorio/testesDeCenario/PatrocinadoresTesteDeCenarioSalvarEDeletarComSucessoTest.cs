using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Testes.InfraStructure;
using NUnit.Framework;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain;
using DDD.Exemplopuro.Domain.Comercial;

namespace DDD.Exemplopuro.Testes.Repositorio
{
    [TestFixture]
    public class PatrocinadoresTesteDeCenarioSalvarEDeletarComSucessoTest : PersistenceTestBase
    {
        public Patrocinadores Patrocinadores { get; set; }
        public Patrocinador Patrocinador { get; set; }

        [SetUp]
        public void SetUp_criar_time_no_banco()
        {
            criar_patrocinador_com_sucesso();
        }

        [TearDown]
        protected void TearDown()
        {
            excluir_patrocinador_com_sucesso();
        }

        private void excluir_patrocinador_com_sucesso()
        {
            Patrocinadores.Deletar(Patrocinador);
        }

        private void criar_patrocinador_com_sucesso()
        {
            Patrocinadores = new Patrocinadores();
            Patrocinadores.InformarSession(base.Session);
            Patrocinador = new Patrocinador("adidas");
            Patrocinadores.Salvar(Patrocinador);
        }

        [Test]
        public void deve_ter_nome_igual_a_adidas()
        {
            Assert.AreEqual(Patrocinador.Nome, "adidas");
        }

        [Test]
        public void deve_ter_id_maior_que_zero()
        {
            Assert.Greater(Patrocinador.Id, default(int));
        }
    }
}
