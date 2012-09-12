using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public class JogadorSoDeveTerUmNoMaximoUmContratoAtivoSpecification : CompositeSpecification
    {
        private Jogador jogador;

        public JogadorSoDeveTerUmNoMaximoUmContratoAtivoSpecification(Jogador jogador)
        {
            this.jogador = jogador;
        }

        public override bool IsSatisfied()
        {
            return jogador.Contratos.Where(c => c.Vigente).Count() <= 1;
        }
    }

}
