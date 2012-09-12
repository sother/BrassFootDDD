using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace DDD.Exemplopuro.Domain
{
    public abstract class Especificacao<T> : ICriterioEspecificacao<T>
    {
        protected virtual T NovaEspecificacao { get; set; }

        public abstract bool EstaSatisfeita();

        public abstract void MontarCriterios(DetachedCriteria criterios);

        public abstract string Notificar();

        public ICriterioEspecificacao<T> And(ICriterioEspecificacao<T> specification)
        {
            return new AndEspecificacao<T>(this, specification);
        }
    }
}
