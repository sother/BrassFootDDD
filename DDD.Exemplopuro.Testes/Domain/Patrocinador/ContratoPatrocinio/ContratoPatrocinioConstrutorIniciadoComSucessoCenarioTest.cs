using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Patrocinio;
using NUnit.Framework;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class ContratoPatrocinioConstrutorIniciadoComSucessoCenarioTest
    {
        public ContratoPatrocinio Contrato { get; set; }

        [SetUp]
        protected virtual void SetUp()
        {
            Contrato = new ContratoPatrocinio(12, 12, 12, 12, new Jogador("ronaldo"));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_meses_de_contrato_informado()
        {
            Assert.Greater(Contrato.MesesDeContrato, default(int));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_valor_base_salario_informado()
        {
            Assert.Greater(Contrato.ValorBaseSalario, default(int));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_valor_base_bonus_informado()
        {
            Assert.Greater(Contrato.ValorBaseBonus, default(int));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_valor_direito_de_imagem_informado()
        {
            Assert.Greater(Contrato.ValorBaseDireitoDeImagem, default(int));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_patrocinado_informado()
        {
            Assert.NotNull(Contrato.Patrocinado);
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_id_igual_a_zero()
        {
            Assert.NotNull(Contrato.Id == 0);
        }
    }
}
