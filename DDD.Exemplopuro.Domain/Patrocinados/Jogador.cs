using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;



namespace DDD.Exemplopuro.Domain
{
    public class Jogador : Patrocinado
    {
        //private ICollection<Contrato> contratos;

        //public virtual ICollection<Contrato> Contratos
        //{
        //    get { return contratos ?? (contratos = new List<Contrato>()); }
        //}

        protected Jogador() { }
        public Jogador(string nome)
            : base(nome)
        {

        }

        public override void Validate()
        {
            base.Validate();
            var noMaximoUmContratoVigente = new JogadorSoDeveTerUmNoMaximoUmContratoAtivoSpecification(this);
            Assertion.IsTrue(noMaximoUmContratoVigente.IsSatisfied(), "Existe mais de um contrato vigente.").Validate();
        }

        public override IList<Patrocinado> ObterTimes()
        {
            return Contratos.Where(c=> c.Vigente).Select(c => c.Time ).ToList();
        }

        public override bool TemVinculo() 
        {
            return Contratos.Where(c => c.Vigente).Count() == 1;
        }

        public override IList<Patrocinado> ObterJogadores()
        {
            throw new ApplicationException("Jogador não é Time.");
        }

        public override void ContratarJogador(Patrocinado jogadorr)
        {
            throw new ApplicationException("Jogador não pode contratar jogador.");
        }

        public override void ResindirContrato(Contrato contrato)
        {
            throw new ApplicationException("somente o time pode resindir o contrato.");
        }
    }
}
