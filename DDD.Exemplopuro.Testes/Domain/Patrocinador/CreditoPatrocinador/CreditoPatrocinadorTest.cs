using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain;
using System.Reflection;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class CreditoPatrocinadorTest
    {
        //[Test]
        //[ExpectedException(ExpectedMessage = "Tipo crédito não informado.")]
        //public void construtor_iniciado_sem_tipo_credito_deve_retornar_execao()
        //{
        //    var credito = new CreditoPatrocinador(null, DateTime.Now, 23);
        //}

        [Test]
        [ExpectedException(ExpectedMessage = "Data do crédito não informada.")]
        public void construtor_iniciado_sem_data_deve_retornar_execao()
        {
            var credito = new CreditoPatrocinador(new TipoCredito(1,"desc"),DateTime.MinValue, 23);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Valor não informado.")]
        public void construtor_iniciado_sem_valor_credito_retornar_execao()
        {
            var credito = new CreditoPatrocinador(new TipoCredito(1, "desc"), DateTime.Now, 0);
        }

        //[Test]
        //[ExpectedException(ExpectedMessage = "Tipo crédito não informado.")]
        //public void validate_sem_tipo_credito_deve_retornar_execao()
        //{
        //    var credito = new CreditoPatrocinador(new TipoCredito(1, "desc"), DateTime.Now, 23);

        //    var tipoCredito = typeof(CreditoPatrocinador).GetField("tipocredito", BindingFlags.NonPublic | BindingFlags.Instance);
        //    tipoCredito.SetValue(credito, null);

        //    credito.Validate();
        //}

        [Test]
        [ExpectedException(ExpectedMessage = "Data do crédito não informada.")]
        public void validate_sem_data_deve_retornar_execao()
        {
            var credito = new CreditoPatrocinador(new TipoCredito(1, "desc"), DateTime.Now, 23);

            var data = typeof(CreditoPatrocinador).GetField("data", BindingFlags.NonPublic | BindingFlags.Instance);
            data.SetValue(credito, null);

            credito.Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Valor não informado.")]
        public void validate_sem_valor_credito_retornar_execao()
        {
            var credito = new CreditoPatrocinador(new TipoCredito(1, "desc"), DateTime.Now, 23);

            var valor = typeof(CreditoPatrocinador).GetField("valor", BindingFlags.NonPublic | BindingFlags.Instance);
            valor.SetValue(credito, null);

            credito.Validate();
        }
    }
}
