using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace DDD.Exemplopuro.Domain
{
    public interface ICriterioEspecificacao<T>
    {
        bool EstaSatisfeita();

        void MontarCriterios(DetachedCriteria criterios);

        string Notificar();

        ICriterioEspecificacao<T> And(ICriterioEspecificacao<T> criterioEspecificacao);
    }
}
