using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public class CreditoPatrocinador : IAggregateRoot<int>
    {
        private int id;
        // private TipoCredito tipocredito;
        private DateTime data;
        private decimal valor;

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }

        //public virtual TipoCredito Tipocredito
        //{
        //    get { return tipocredito; }
        //}

        public virtual DateTime Data
        {
            get { return data; }
        }

        public virtual decimal Valor
        {
            get { return valor; }
        }

        protected CreditoPatrocinador() { }

        public CreditoPatrocinador(TipoCredito tipo, DateTime data, decimal valor)
        {
            #region Pré-Condições
           // Assertion.NotNull(tipo, "Tipo crédito não informado.").Validate();
            Assertion.GreaterThan(data, DateTime.MinValue, "Data do crédito não informada.").Validate();
            Assertion.GreaterThan(valor, default(decimal), "Valor não informado.").Validate();
            #endregion

            //  this.tipocredito = tipo;
            this.data = data;
            this.valor = valor;

            #region Pós-Condições
            this.Validate();
            #endregion
        }

        public virtual void Validate()
        {
            //    IAssertion tipoCreditoInformado = Assertion.NotNull(tipocredito, "Tipo crédito não informado.");
            IAssertion dataCreditoInformada = Assertion.GreaterThan(data, DateTime.MinValue, "Data do crédito não informada.");
            IAssertion valorInformado = Assertion.GreaterThan(valor, default(decimal), "Valor não informado.");

            //tipoCreditoInformado
            dataCreditoInformada.and(valorInformado).Validate();
        }



    }
}
