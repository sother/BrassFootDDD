using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public enum TipoCreditoEnum : short
    {
        salario = 1,
        bonus = 2,
        direitoDeImagem = 3
    }

    public class TipoCredito : ValueObject
    {
        protected TipoCredito() { }

        public TipoCredito(int id, string descricao)
            : base(id, descricao)
        { }
    }
}
