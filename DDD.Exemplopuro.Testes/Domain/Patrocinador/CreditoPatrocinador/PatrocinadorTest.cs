using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Patrocinio;
using NUnit.Framework;
using patrocinador = DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain;
using System.Reflection;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class PatrocinadorTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_nome_preenchido_com_sucesso()
        {
            
            patrocinador.Patrocinador adidas = new patrocinador.Patrocinador("Adidas Sa");
            Patrocinado botafogo = new Time("bo");
            Patrocinado bo= new Jogador("bo");

            Assert.Greater(adidas.Nome, string.Empty);
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_id_igual_a_zero()
        {
            patrocinador.Patrocinador adidas = new patrocinador.Patrocinador("Adidas Sa");

            Assert.AreEqual(adidas.Id, 0);
        }

        [Test]
        public void adicionar_contrato_com_sucesso_deve_ter_contrato_na_lista_de_contratos()
        {
            patrocinador.Patrocinador adidas = new patrocinador.Patrocinador("Adidas Sa");
            var contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            adidas.AdicionarPatrocinado(contrato);

            Assert.IsTrue(adidas.Patrocinados.Contains(contrato));
        }

        [Test]
        public void criar_credito_com_sucesso() 
        {
            patrocinador.Patrocinador adidas = new patrocinador.Patrocinador("Adidas Sa");
            var contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var criarCredito = typeof(patrocinador.Patrocinador).GetMethod("CriarCredito", BindingFlags.NonPublic | BindingFlags.Instance);
            CreditoPatrocinador credito =(CreditoPatrocinador) criarCredito.Invoke(adidas, new object[] {(decimal)10,DateTime.Now, new TipoCredito(1,"desc") });

            Assert.NotNull(credito);
        }
    }
}
