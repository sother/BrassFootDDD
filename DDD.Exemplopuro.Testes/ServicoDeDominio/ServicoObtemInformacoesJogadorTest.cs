using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain.Servico;
using DDD.Exemplopuro.Domain.Repositorio;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Testes.ServicoDeDominio
{
    [TestFixture]
    public class ServicoObtemInformacoesJogadorTest : TesteBase
    {
        public Patrocinadores Patrocinadores { get; set; }
        public Patrocinador Patrocinador { get; set; }
        public Patrocinados Patrocinados { get; set; }
        public Patrocinado Patrocinado { get; set; }

        protected override void SetUp()
        {
            base.SetUp();
            
            Patrocinados = new Patrocinados();
            Patrocinado = new Jogador("ronaldo");
            Patrocinados.Salvar(Patrocinado);


            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, Patrocinado);

            Patrocinadores = new Patrocinadores();
            Patrocinador = new Patrocinador("Adidas");
            Patrocinador.AdicionarPatrocinado(contrato);
            
            
            

        }

        [Test]
        public void obter_historico_time_com_sucesso()
        {
            var servico = new ServicoObtemInformacoesJogador();

            servico.ObterTimesJogador(null);
        }
    }
}
