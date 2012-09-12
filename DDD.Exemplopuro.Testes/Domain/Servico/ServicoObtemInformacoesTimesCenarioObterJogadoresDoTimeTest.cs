using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ServicoObtemInformacoesTimesCenarioObterJogadoresDoTimeTest : TesteBase
    {
        public Patrocinados Patrocinados { get; set; }
        public Patrocinado Time { get; set; }
        public Patrocinado Jogador { get; set; }
        public IEnumerable<Patrocinado> Jogadores { get; set; }
        Patrocinador Patrocinador { get; set; }
        Patrocinadores Patrocinadores { get; set; }

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            Patrocinados = new Patrocinados();
            Patrocinadores = new Patrocinadores();
            criar_time_com_sucesso();
            criar_jogador_com_sucesso();
            criar_patrocinador_com_sucesso();
            criar_contrato_para_jogador_e_time_para_este_patrocinador();
            criar_contrato_entre_time_e_patrocinador();

            var servico = new ServicoObtemInformacoesTime();

            Jogadores = servico.ObterJogadoresTime(Time);
        }

        private void criar_contrato_entre_time_e_patrocinador()
        {
            Patrocinador.ContratarJogador(Time, Jogador);
            Patrocinados.Salvar(Time);
        }

        private void criar_contrato_para_jogador_e_time_para_este_patrocinador()
        {
            var contratojogador = new ContratoPatrocinio(12, 12, 1233, 12, Jogador);
            var contratoTime = new ContratoPatrocinio(12, 12, 1233, 12, Time);

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
            TipoCredito tipoCredito =  tipo.Obter(1);
            CreditoPatrocinador credito = new CreditoPatrocinador(tipoCredito, DateTime.Now, 10);

            var receberPagamento = typeof(Patrocinado).GetMethod("ReceberPagamento", BindingFlags.NonPublic | BindingFlags.Instance);
            receberPagamento.Invoke(Time, new object[] { credito });
            Patrocinados.Salvar(Time);
        }

        [Test]
        public void deve_haver_um_jogador_apenas()
        {
            Assert.IsTrue(Jogadores.Count() == 1);
        }

        [Test]
        public void nome_do_jogador_deve_ser_ronaldo()
        {
            Assert.AreEqual(Jogadores.FirstOrDefault().Nome, "ronaldo");
        }
    }
}
