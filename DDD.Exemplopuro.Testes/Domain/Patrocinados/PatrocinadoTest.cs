using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using System.Reflection;
using PostSharp.Laos.Serializers;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class PatrocinadoTest
    {
        [Test]
        public void receber_pagamento_deve_ter_credito_na_lista_de_creditos()
        {
            Patrocinado botafogo = new Time("Botagogo de Futebol de Regatas sa.");

            CreditoPatrocinador credito = new CreditoPatrocinador(new TipoCredito(1, "descricao"), DateTime.Now, 10);

            var receberPagamento = typeof(Patrocinado).GetMethod("ReceberPagamento", BindingFlags.NonPublic | BindingFlags.Instance);
            receberPagamento.Invoke(botafogo, new object[] { credito });

            Assert.IsTrue(botafogo.Creditos.Contains(credito));
        }

    }
}
