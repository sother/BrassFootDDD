using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Comercial;

namespace DDD.Exemplopuro.Domain.Servico
{
    public class ServicoObtemInformacoesJogador
    {
        public IEnumerable<Patrocinado> ObterTimesJogador(Patrocinado jogador)
        {
            return jogador.ObterTimes();
        }
    }   
}
