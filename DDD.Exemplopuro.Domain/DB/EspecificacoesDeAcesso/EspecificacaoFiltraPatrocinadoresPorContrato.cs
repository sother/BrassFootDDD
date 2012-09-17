using System;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.ExemploPuro.Framework;
using DDD.Exemplopuro.Domain.Patrocinio;
using NHibernate.Criterion;
using NHibernate;

namespace DDD.Exemplopuro.Domain.DB.EspecificacoesDeAcesso
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
