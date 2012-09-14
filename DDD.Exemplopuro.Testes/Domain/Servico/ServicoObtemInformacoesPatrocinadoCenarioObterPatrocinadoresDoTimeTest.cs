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

namespace DDD.Exemplopuro.Testes.Domain.Servico
{
    [TestFixture]
    public class ServicoObtemInformacoesPatrocinadoCenarioObterPatrocinadoresDoTimeTest : PersistenceTestBase
    {

        Patrocinado Patrocinado { get; set; }
        Patrocinados Patrocinados { get; set; }
        Patrocinador Patrocinador { get; set; }
        Patrocinadores Patrocinadores { get; set; }
        IEnumerable<Patrocinador> PatrocinadoresObtidos { get; set; }

        [SetUp]
        protected void SetUp()
        {
            Patrocinadores = new Patrocinadores();
            Patrocinadores.InformarSession(base.Session);
            Patrocinados = new Patrocinados();
            Patrocinados.InformarSession(base.Session);
            criar_time();
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

        private void criar_time()
        {
            Patrocinado = new Time("barcelona");
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
