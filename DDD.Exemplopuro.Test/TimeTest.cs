using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Test
{
    [TestFixture]
    public class TimeTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_nome_time_preenchido()
        {
            Time botafogo = new Time("botafogo");

            Assert.IsFalse(string.IsNullOrEmpty(botafogo.NomeTime)); 
        }

        [Test]
        [ExpectedException(ExpectedMessage="")]
        public void construtor_iniciado_com_nome_vazio_deve_retornar_execao()
        {
            Time botafogo = new Time("");
        }


    }
}
