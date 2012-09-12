using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DDD.Exemplopuro.Domain;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Testes.Framework
{
    [TestFixture]
    public class ValueObjectTest
    {
        [Test]
        [ExpectedException(ExpectedMessage = "Id Informado.")]
        public void construtor_iniciado_com_sem_id_preenchido_deve_retornar_execao()
        {
            ValueObject tipoCredito = new TipoCredito(0, "desc");
        }

        [Test]
        [ExpectedException(ExpectedMessage = "Descrição não Informada.")]
        public void construtor_iniciado_com_sem_descricao_preenchido_deve_retornar_execao()
        {
            ValueObject tipoCredito = new TipoCredito(12, "");
        }

    
    }
}
