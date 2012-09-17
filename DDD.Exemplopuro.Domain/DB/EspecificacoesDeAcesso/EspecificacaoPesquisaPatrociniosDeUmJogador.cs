using System;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain.DB.EspecificacoesDeAcesso
{
    public class EspecificacaoPesquisaPatrociniosDeUmJogador : Especificacao<Patrocinado>
    {
        protected Patrocinado Patrocinado { get; set; }

        public EspecificacaoPesquisaPatrociniosDeUmJogador(Patrocinado patrocinado)
        {
            Assertion.NotNull(patrocinado, "Patrocinado não informado.").Validate();

            this.Patrocinado = patrocinado;
        }

        public override bool EstaSatisfeita()
        {
            return true;
        }

        public override void MontarCriterios(NHibernate.Criterion.DetachedCriteria criterios)
        {
            throw new NotImplementedException();
        }

        public override string Notificar()
        {
            throw new NotImplementedException();
        }
    }
}
