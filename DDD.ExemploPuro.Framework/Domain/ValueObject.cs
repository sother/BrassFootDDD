using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.ExemploPuro.Framework
{
    public abstract class ValueObject
    {
        private int id;
        private string descricao;

        public virtual int Id
        {
            get { return id; }
        }

        public virtual string Descricao
        {
            get { return descricao; }
        }

        protected ValueObject() { }

        protected ValueObject(int id, string descricao)
        {
            Assertion.GreaterThan(descricao, string.Empty, "Descrição não Informada.").Validate();
            Assertion.GreaterThan(id, default(int), "Id Informado.").Validate();

            this.id = id;
            this.descricao = descricao;

            this.Validate();
        }


        public virtual void Validate()
        {
            Assertion.GreaterThan(this.descricao, string.Empty, "Descrição não Informada.").Validate();
            Assertion.GreaterThan(this.id, default(int), "Id Informado.").Validate();
        }
    }
}
