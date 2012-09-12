using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class CreditoPatrocinadorConstrutorIniciadoComSucessoTest
    {
        public CreditoPatrocinador Credito { get; set; }

        [SetUp]
        protected virtual void SetUp()
        {
            Credito = new CreditoPatrocinador(new TipoCredito(1, "descri"), DateTime.Now, 23);
        }

        //[Test]
        //public void construtor_iniciado_com_sucesso_deve_ter_tipo_de_credito_informado()
        //{
        //    Assert.NotNull(Credito.Tipocredito);
        //}

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_data_informada()
        {
            Assert.Greater(Credito.Data,DateTime.MinValue);
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_valor_informado()
        {
            Assert.Greater(Credito.Valor,default(decimal));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_Id_igual_a_zero()
        {
            Assert.AreEqual(Credito.Id, 0);
        } 
    }
}
