using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;
using NHibernate.Criterion;

namespace DDD.Exemplopuro.Domain
{
    public class EspecificacaoFiltrarContratosPorPatrocinado : EspecificacaoPesquisaPatrociniosDeUmJogador
    {
        public EspecificacaoFiltrarContratosPorPatrocinado(Patrocinado patrocinado)
            : base(patrocinado) 
        {
        }

        public override void MontarCriterios(NHibernate.Criterion.DetachedCriteria criterios)
        {
            #region Pré-condições
            Assertion.NotNull(criterios, "Criterios está nulo").Validate();
            #endregion

            if (EstaSatisfeita())
            {
                criterios.Add(Expression.Eq("Patrocinado", this.Patrocinado));
                criterios.SetProjection(Projections.Id());
            }
        }

        public override string Notificar()
        {
            return base.Notificar();
        }


    }
}
