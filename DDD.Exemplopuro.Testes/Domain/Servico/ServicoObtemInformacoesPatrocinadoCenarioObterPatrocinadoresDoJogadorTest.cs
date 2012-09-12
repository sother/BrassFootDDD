using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain.Servico;

namespace DDD.Exemplopuro.Testes.Domain.Servico
{
    [TestFixture]
    public class ServicoObtemInformacoesPatrocinadoCenarioObterPatrocinadoresDoJogadorTest : TesteBase
    {
        Patrocinado Patrocinado { get; set; }
        Patrocinados Patrocinados { get; set; }
        Patrocinador Patrocinador { get; set; }
        Patrocinadores Patrocinadores { get; set; }
        IEnumerable<Patrocinador> PatrocinadoresObtidos { get; set; }

        protected override void SetUp()
        {
            base.SetUp();
            Patrocinadores = new Patrocinadores();
            Patrocinados = new Patrocinados();
            criar_jogador();
            criar_patrocinador();
            criar_contrato_patrocinio();

            var servico = new ServicoObtemInformacoesPatrocinados();
            PatrocinadoresObtidos = servico.ObterPatrocinadores(Patrocinado);
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
            Patrocinadores.Salvar(Patrocinador);
        }

        private void criar_jogador()
        {
            Patrocinado = new Jogador("ronaldo");
            Patrocinados.Salvar(Patrocinado);
        }

        [Test]
        public void servico_deve_obter_patrocinadores()
        {
            Assert.NotNull(PatrocinadoresObtidos);

        }

        [Test]
        public void servico_deve_obter_apenas_um_patrocinador()
        {
            Assert.AreEqual(PatrocinadoresObtidos.Count(), 1);

        }

        [Test]
        public void servico_deve_obter_apenas_um_patrocinador_com_nome_igual_Adidas()
        {
            Assert.AreEqual(PatrocinadoresObtidos.FirstOrDefault().Nome, "Adidas");

        }
    }
}
