using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using System.Reflection;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class JogadorTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_nome_preenchido()
        {
            Patrocinado ronaldo = new Jogador("ronaldo");

            Assert.IsFalse(string.IsNullOrEmpty(ronaldo.Nome));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Nome do patrocinado não informado.")]
        public void construtor_iniciado_com_nome_vazio_deve_retornar_execao()
        {
            Patrocinado ronaldo = new Jogador("");
            
        }

        [Test]
        public void validar_jogador_com_sucesso_deve_ter_nome_jogador_preenchido()
        {
            Patrocinado ronaldo = new Jogador("ronaldo");

            ronaldo.Validate();
            Assert.IsFalse(string.IsNullOrEmpty(ronaldo.Nome));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Nome do patrocinado não informado.")]
        public void validar_jogador_e_nome_vazio_deve_retornar_execao()
        {
            Patrocinado ronaldo = new Jogador("ronaldo");

            var nome = typeof(Patrocinado).GetField("nome", BindingFlags.NonPublic | BindingFlags.Instance);
            nome.SetValue(ronaldo, "");

            ronaldo.Validate();
        }
    }
}
