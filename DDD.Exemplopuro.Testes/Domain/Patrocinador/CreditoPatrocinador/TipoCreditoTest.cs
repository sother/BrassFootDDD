using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;

namespace DDD.Exemplopuro.Testes.Domain.Patrocinador.CreditoPatrocinador
{
    [TestFixture]
    public class TipoCreditoTest
    {
        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_id_preenchido()
        {
            TipoCredito credito = new TipoCredito(2, "desc");

            Assert.Greater(credito.Id, default(int));
        }

        [Test]
        public void construtor_iniciado_com_sucesso_deve_ter_descricao_preenchida() { }

        [Test]
        public void validar_sem_id_deve_retornar_execao() { }

        [Test]
        public void validar_sem_descricao_deve_retornar_execao() { }
    }
}
