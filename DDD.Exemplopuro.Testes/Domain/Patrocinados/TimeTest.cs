using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using System.Reflection;

namespace DDD.Exemplopuro.Testes
{
    [TestFixture]
    public class TimeTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_nome_time_preenchido()
        {
            Time botafogo = new Time("botafogo");

            Assert.IsFalse(string.IsNullOrEmpty(botafogo.Nome));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_Id_igual_a_zero()
        {
            Time botafogo = new Time("botafogo");

            Assert.IsTrue(botafogo.Id == 0);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Nome do patrocinado não informado.")]
        public void construtor_iniciado_com_nome_vazio_deve_retornar_execao()
        {
            Time botafogo = new Time("");
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Nome do patrocinado não informado.")]
        public void validar_time_e_nome_vazio_deve_retornar_execao()
        {
            Patrocinado botafogo = new Time("botafogo");

            var nome = typeof(Patrocinado).GetField("nome", BindingFlags.NonPublic | BindingFlags.Instance);
            nome.SetValue(botafogo, "");

            botafogo.Validate();
        }

        [Test]
        public void validar_time_com_sucesso()
        {
            Time botafogo = new Time("botafogo");

            botafogo.Validate();

            Assert.IsFalse(string.IsNullOrEmpty(botafogo.Nome));
        }
    }
}
