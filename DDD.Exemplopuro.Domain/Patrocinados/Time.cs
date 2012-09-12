using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public class Time : Patrocinado
    {
        protected Time() { }

        public Time(string nomeTime)
            : base(nomeTime)
        {
        }

        public override IList<Patrocinado> ObterTimes()
        {
            throw new ApplicationException("Time não é jogador.");
        }

        public override IList<Patrocinado> ObterJogadores()
        {
            return Contratos.Where(c => c.Vigente).Select(c => c.Jogador).ToList();
        }

        public override void ContratarJogador(Patrocinado jogador)
        {
            #region Pré-Condições
            Assertion.IsTrue(this.SaldoPositivo(), "Saldo do time deve ser positivo para contratar Jogadores").Validate();
            Assertion.IsFalse(jogador.TemVinculo(), "Jogador tem vinculo com algum clube, antes de firmar contrato pague a multa para o time.").Validate();
            #endregion

            var contratoNovo = new Contrato(this, jogador);

            Assertion.NotNull(contratoNovo, "Contrato não foi criado.").Validate();
            Assertion.NotNull(contratoNovo.Time, "Contrato não foi criado.").Validate();
            Assertion.NotNull(contratoNovo.Jogador, "Contrato não foi criado.").Validate();
        }

        public override void ResindirContrato(Contrato contrato)
        {
            Assertion.IsTrue(base.MeuContrato(contrato), "Este contrato não pertence a este Time.").Validate();
            Assertion.IsTrue(contrato.Vigente, "Este contrato não está vigente.").Validate();

            contrato.RencindirContrato();

            Assertion.IsFalse(contrato.Vigente, "Contrato não foi finalizado.").Validate();
        }

        public override bool TemVinculo()
        {
            return this.Contratos.Where(c => c.Vigente).Count() > 0;
        }
    }
}
