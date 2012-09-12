using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Repositorio;

namespace DDD.Exemplopuro.Domain.Servico
{
    public class ServicoObtemInformacoesPatrocinados
    {
        public IEnumerable<Patrocinador> ObterPatrocinadores(Patrocinado patrocinado)
        {
            Patrocinadores patrocinadores = new Patrocinadores();
            return patrocinadores.ObterTodosPatrocinadosQueTenhamContratoCom(patrocinado);
        }

        public Patrocinador ObterPatrocinadorAtual(Patrocinado patrocinado)
        {
            Patrocinadores patrocinadores = new Patrocinadores();
            return patrocinadores.ObterPatrocinadorAtual(patrocinado);
        }
    }
}
