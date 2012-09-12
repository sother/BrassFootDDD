using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Testes.Domain
{
    [TestFixture]
    public class TipoCreditoPatrocinadorTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_id_preenchido()
        {
            ValueObject tipoCredito = new TipoCredito(1, "desc");

            Assert.Greater(tipoCredito.Id, 0);
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_descricao_preenchida()
        {
            ValueObject tipoCredito = new TipoCredito(1, "desc");

            Assert.Greater(tipoCredito.Descricao, string.Empty);
        }

    
    }
}
