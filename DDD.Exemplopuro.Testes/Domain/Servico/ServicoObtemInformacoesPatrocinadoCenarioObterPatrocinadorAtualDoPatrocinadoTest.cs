using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Testes.InfraStructure;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain.Servico;
using System.Reflection;


namespace DDD.Exemplopuro.Testes.Domain.Servico
{
    [TestFixture]
    public class ServicoObtemInformacoesPatrocinadoCenarioObterPatrocinadorAtualDoPatrocinadoTest : PersistenceTestBase
    {
        Patrocinado Patrocinado { get; set; }
        Patrocinados Patrocinados { get; set; }
        Patrocinador Patrocinador { get; set; }
        Patrocinadores Patrocinadores { get; set; }
        Patrocinador PatrocinadorObtido { get; set; }

        [SetUp]
        protected void SetUp()
        {
            Patrocinadores = new Patrocinadores();
            Patrocinadores.InformarSession(base.Session);
            Patrocinados = new Patrocinados();
            Patrocinados.InformarSession(base.Session);
            criar_jogador();
            criar_patrocinador();
            criar_contrato_patrocinio();

            var servico = new ServicoObtemInformacoesPatrocinados();
            PatrocinadorObtido = servico.ObterPatrocinadorAtual(Patrocinado);
        }

        private void criar_contrato_patrocinio()
        {
            var contrato = new ContratoPatrocinio(12, 12, 1233, 12, Patrocinado);
            Patrocinador.AdicionarPatrocinado(contrato);
            Patrocinadores.Salvar(Patrocinador);
        }

        private void criar_patrocinador()
        {
            Patrocinador = new Patrocinador("Adidas");
            
        }

        private void criar_jogador()
        {
            Patrocinado = new Jogador("ronaldo");
            Patrocinados.Salvar(Patrocinado);
        }

        [Test]
        public void patrocinador_deve_ser_nao_nulo()
        {
            Assert.NotNull(PatrocinadorObtido);

        }

        [Test]
        public void nome_igual_Adidas()
        {
            Assert.AreEqual(PatrocinadorObtido.Nome, "Adidas");

        }
    }
}
