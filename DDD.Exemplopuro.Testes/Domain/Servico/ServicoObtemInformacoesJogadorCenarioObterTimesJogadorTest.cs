using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Testes.InfraStructure;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using DDD.Exemplopuro.Domain.Servico;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain.DB.Repositorio;
using System.Reflection;

namespace DDD.Exemplopuro.Testes.Domain.Servico
{
    [TestFixture]
    public class ServicoObtemInformacoesJogadorCenarioObterTimesJogadorTest : PersistenceTestBase
    {
        public Patrocinados Patrocinados { get; set; }
        public Patrocinado Time { get; set; }
        public Patrocinado Jogador { get; set; }
        public IEnumerable<Patrocinado> Times { get; set; }
        Patrocinador Patrocinador { get; set; }
        Patrocinadores Patrocinadores { get; set; }

        private ContratoPatrocinio contratojogador;
        private ContratoPatrocinio contratoTime;

        [SetUp]
        protected void SetUp()
        {
            Patrocinados = new Patrocinados();
            Patrocinados.InformarSession(base.Session);
            Patrocinadores = new Patrocinadores();
            Patrocinadores.InformarSession(base.Session);
            criar_time_com_sucesso();
            criar_jogador_com_sucesso();
            criar_patrocinador_com_sucesso();
            criar_contrato_para_jogador_e_time_para_este_patrocinador();
            criar_contrato_entre_time_e_jogador();

            var servico = new ServicoObtemInformacoesJogador();

            Times = servico.ObterTimesJogador(Jogador);
        }

        private void criar_contrato_entre_time_e_jogador()
        {
            Patrocinador.ContratarJogador(Time, Jogador);
            Patrocinados.Salvar(Time);
        }

        private void criar_contrato_para_jogador_e_time_para_este_patrocinador()
        {
            contratojogador = new ContratoPatrocinio(12, 12, 1233, 12, Jogador);
            contratoTime = new ContratoPatrocinio(12, 12, 1233, 12, Time);

            Patrocinador.AdicionarPatrocinado(contratojogador);
            Patrocinador.AdicionarPatrocinado(contratoTime);

            Patrocinadores.Salvar(Patrocinador);
        }

        private void criar_patrocinador_com_sucesso()
        {
            Patrocinador = new Patrocinador("Adidas");
        }

        private void criar_jogador_com_sucesso()
        {
            Jogador = new Jogador("ronaldo");
            Patrocinados.Salvar(Jogador);
        }

        private void criar_time_com_sucesso()
        {
            Time = new Time("barcelona");
            Tipos<TipoCredito> tipo = new Tipos<TipoCredito>();
            TipoCredito tipoCredito = tipo.Obter(1);
            CreditoPatrocinador credito = new CreditoPatrocinador(tipoCredito, DateTime.Now, 10);

            var receberPagamento = typeof(Patrocinado).GetMethod("ReceberPagamento", BindingFlags.NonPublic | BindingFlags.Instance);
            receberPagamento.Invoke(Time, new object[] { credito });
            Patrocinados.Salvar(Time);
        }

        [Test]
        public void deve_haver_um_time_apenas()
        {
            Assert.IsTrue(Times.Count() == 1);
        }

        [Test]
        public void nome_do_time_deve_ser_barcenola()
        {
            Assert.AreEqual(Times.FirstOrDefault().Nome, "barcelona");
        }
    }
}
