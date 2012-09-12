using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.ExemploPuro.Framework;
using NHibernate.Criterion;
using NHibernate;

namespace DDD.Exemplopuro.Domain
{
    public class EspecificacaoFiltraPatrocinadoresPorContrato : Especificacao<ContratoPatrocinio>
    {
        protected ICriteria Contratos { get; set; }

        public override bool EstaSatisfeita()
        {
            throw new NotImplementedException();
        }


        public EspecificacaoFiltraPatrocinadoresPorContrato(ICriteria contratos) 
        {
            Assertion.NotNull(contratos, "Contrato está nulo.").Validate();

            this.Contratos = contratos;
        }

        public override void MontarCriterios(NHibernate.Criterion.DetachedCriteria criterios)
        {
            this.Contratos.Add(Subqueries.PropertyIn("Patrocinados", criterios)); 
        }

        public override string Notificar()
        {
            throw new NotImplementedException();
        }
    }
}
