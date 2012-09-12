using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;
using NHibernate.Criterion;

namespace DDD.Exemplopuro.Domain
{
    public class EspecificacaoFiltrarContratosAtivos : EspecificacaoPesquisaPatrociniosDeUmJogador
    {
        public EspecificacaoFiltrarContratosAtivos(Patrocinado patrocinado)
            : base(patrocinado)
        {
        }

        public override void MontarCriterios(NHibernate.Criterion.DetachedCriteria criterios)
        {
            #region Pré-condições
            Assertion.NotNull(criterios, "Criterios está nulo").Validate();
            #endregion

            criterios.Add(Expression.Eq("Vigente", true));
        }

        public override string Notificar()
        {
            return base.Notificar();
        }


    }
}
