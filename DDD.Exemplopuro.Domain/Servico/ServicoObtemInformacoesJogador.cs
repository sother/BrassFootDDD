using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.Exemplopuro.Domain.Comercial;
using DDD.Exemplopuro.Domain.Repositorio;

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
