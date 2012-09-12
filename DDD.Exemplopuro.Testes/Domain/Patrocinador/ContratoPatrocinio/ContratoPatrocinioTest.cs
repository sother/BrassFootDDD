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
    public class ContratoPatrocinioTest
    {
        [Test]
        [ExpectedException(ExpectedMessage = "Não fora informados meses de contrato.")]
        public void construtor_iniciado_sem_mes_de_contrato_deve_retornar_execao()
        {
           ContratoPatrocinio contrato = new ContratoPatrocinio(0, 12, 12, 12, new Jogador("ronaldo"));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base bonûs.")]
        public void construtor_iniciado_sem_valor_base_bonus_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 0, 12, 12, new Jogador("ronaldo"));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base salario.")]
        public void construtor_iniciado_sem_valor_base_salario_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 0, 12, new Jogador("ronaldo"));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base direito de imagem.")]
        public void construtor_iniciado_sem_valor_base_direito_de_imagem_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 0, new Jogador("ronaldo"));
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado um patrocinado.")]
        public void construtor_iniciado_sem_jogador_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, null);
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não fora informados meses de contrato.")]
        public void validar_sem_mes_de_contrato_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var mesesDeContrato = typeof(ContratoPatrocinio).GetField("mesesDeContrato", BindingFlags.NonPublic | BindingFlags.Instance);
            mesesDeContrato.SetValue(contrato, 0);

            contrato.Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base bonûs.")]
        public void validar_iniciado_sem_valor_base_bonus_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var valorBaseBonus = typeof(ContratoPatrocinio).GetField("valorBaseBonus", BindingFlags.NonPublic | BindingFlags.Instance);
            valorBaseBonus.SetValue(contrato, default(decimal));

            contrato.Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base salario.")]
        public void validar_iniciado_sem_valor_base_salario_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var valorBaseSalario = typeof(ContratoPatrocinio).GetField("valorBaseSalario", BindingFlags.NonPublic | BindingFlags.Instance);
            valorBaseSalario.SetValue(contrato, default(decimal));

            contrato.Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado valor base direito de imagem.")]
        public void validar_iniciado_sem_valor_base_direito_de_imagem_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var valorBaseDireitoDeImagem = typeof(ContratoPatrocinio).GetField("valorBaseDireitoDeImagem", BindingFlags.NonPublic | BindingFlags.Instance);
            valorBaseDireitoDeImagem.SetValue(contrato,default(decimal));

            contrato.Validate();
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Não foi informado um patrocinado.")]
        public void validar_iniciado_sem_jogador_deve_retornar_execao()
        {
            ContratoPatrocinio contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));

            var patrocinado = typeof(ContratoPatrocinio).GetField("patrocinado", BindingFlags.NonPublic | BindingFlags.Instance);
            patrocinado.SetValue(contrato, null);

            contrato.Validate();
        }
    }
}
