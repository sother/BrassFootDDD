using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace DDD.Exemplopuro.Domain
{
    public class AndEspecificacao<T> : Especificacao<T>
    {
        private readonly ICriterioEspecificacao<T> criterioEspecificacao1;
        private readonly ICriterioEspecificacao<T> criterioEspecificacao2;

        public AndEspecificacao(ICriterioEspecificacao<T> criterioEspecificacao1, ICriterioEspecificacao<T> criterioEspecificacao2)
        {
            this.criterioEspecificacao1 = criterioEspecificacao1;
            this.criterioEspecificacao2 = criterioEspecificacao2;
        }

        public override bool EstaSatisfeita()
        {
            return criterioEspecificacao1.EstaSatisfeita() && criterioEspecificacao2.EstaSatisfeita();
        }

        public override void MontarCriterios(DetachedCriteria criterios)
        {
            criterioEspecificacao1.MontarCriterios(criterios);
            criterioEspecificacao2.MontarCriterios(criterios);
        }

        public override string Notificar()
        {
            return string.Concat(criterioEspecificacao1.Notificar(), criterioEspecificacao2.Notificar());
        }
    }
}
