using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Exemplopuro.Domain.Servico
{
    public class ServicoObtemInformacoesTime
    {
        public IEnumerable<Patrocinado> ObterJogadoresTime(Patrocinado time)
        {
            return time.ObterJogadores();
        }
    }
}
