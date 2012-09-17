﻿using System.Collections.Generic;
using System.Linq;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.DB.EspecificacoesDeAcesso;
using DDD.Exemplopuro.Domain.Patrocinio;
using NHibernate.Criterion;
using NHibernate;
using NHibernate.Transform;

namespace DDD.Exemplopuro.Domain.DB.Repositorio
{
    public class Patrocinadores : BaseRepository
    {
        public Patrocinadores()
        {

        }

        public Patrocinadores(ISession session)
            : base(session)
        {

        }

        public void Salvar(Patrocinador patrocinado)
        {
            base.Salvar(patrocinado);
        }

        public Patrocinador Obter(int id)
        {
            return base.Obter<Patrocinador>(id);
        }

        public void Excluir(Patrocinador patrocinado)
        {
            base.Deletar(patrocinado);
        }

        public IList<Patrocinador> ObterTodosPatrocinadosQueTenhamContratoCom(Patrocinado patrocinado)
        {
            var contratos = DetachedCriteria.For<ContratoPatrocinio>();

            var filtraContratosPorPatrocinado = new EspecificacaoFiltrarContratosPorPatrocinado(patrocinado);
            filtraContratosPorPatrocinado.MontarCriterios(contratos);

            var patrocinadores = Session.CreateCriteria<Patrocinador>();

            var filtraPatrocinadorPorContratos = new EspecificacaoFiltraPatrocinadoresPorContrato(patrocinadores);
            filtraPatrocinadorPorContratos.MontarCriterios(contratos);

            return patrocinadores.SetFetchMode("Patrocinados", FetchMode.Eager)
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .List<Patrocinador>().ToList();
        }

        public Patrocinador ObterPatrocinadorAtual(Patrocinado patrocinado)
        {
            var contratos = DetachedCriteria.For<ContratoPatrocinio>();

            var filtraContratosPorPatrocinado = new EspecificacaoFiltrarContratosPorPatrocinado(patrocinado);
            var filtrarContratosAtivos = new EspecificacaoFiltrarContratosAtivos(patrocinado);
            filtraContratosPorPatrocinado.And(filtrarContratosAtivos).MontarCriterios(contratos);

            var patrocinadores = Session.CreateCriteria<Patrocinador>();
            var filtraPatrocinadorPorContratos = new EspecificacaoFiltraPatrocinadoresPorContrato(patrocinadores);
            filtraPatrocinadorPorContratos.MontarCriterios(contratos);

            return patrocinadores.UniqueResult<Patrocinador>();
        }
    }
}
