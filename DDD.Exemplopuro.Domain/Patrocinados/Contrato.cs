using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public class Contrato : IAggregateRoot<int>
    {
        private int id;
        private Patrocinado time;
        private DateTime? dataInicio;
        private DateTime? dataFinal;
        private bool vigente;
        private Patrocinado jogador;

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }

        public virtual DateTime? DataInicio
        {
            get { return dataInicio; }
        }

        public virtual DateTime? DataFinal
        {
            get { return dataFinal; }
        }

        public virtual Patrocinado Time
        {
            get { return time; }
        }
        public virtual Patrocinado Jogador
        {
            get { return jogador; }
        }

        public virtual bool Vigente
        {
            get { return vigente; }
        }

        protected Contrato() { }

        public Contrato(Patrocinado time, Patrocinado jogador)
        {
            #region Pré-Condições
            Assertion.NotNull(time, "Time não informado.").Validate();
            time.Validate();
            #endregion

            InformarTime(time);
            InformarJogador(jogador);
            IniciarDataVigencia();
            IniciarVigencia();
            AdicionarCopiaContratoAoTime();
            AdicionarCopiaContratoAoJogador();

            #region Pós-Condições
            this.Validate();
            #endregion
        }

        private void AdicionarCopiaContratoAoJogador()
        {
            this.time.AdicionarContrato(this);
        }

        private void AdicionarCopiaContratoAoTime()
        {
            this.jogador.AdicionarContrato(this); 
        }    

        private void InformarJogador(Patrocinado jogador)
        {

            #region Pré-Condições
            Assertion.NotNull(time, "Jogador não informado.").Validate();
          //  Assertion.IsTrue(jogador.TipoPatrocinado == TipoPatrocinadoEnum.jogador, "Jogador não informado.").Validate();
            time.Validate();
            #endregion

            this.jogador = jogador;

            Assertion.Equals(this.time, time, "Time não foi informado corretamente.").Validate();
        }

        public virtual void InformarTime(Patrocinado time)
        {
            #region Pré-Condições
            Assertion.NotNull(time, "Time não informado.").Validate();
           // Assertion.IsTrue(time.TipoPatrocinado == TipoPatrocinadoEnum.time, "Time não informado.").Validate();
            time.Validate();
            #endregion

            this.time = time;

            Assertion.Equals(this.time, time, "Time não foi informado corretamente.").Validate();
        }

        public virtual void RencindirContrato()
        {
            #region Pré-Condições
            Assertion.IsTrue(vigente, "Este contrato não está vigente para ser finalizado.").Validate();
            #endregion

            FinalizarDataVigencia();
            this.FinalizarVigencia();
            
            #region Pós-Condições
            Assertion.GreaterThan(dataFinal, DateTime.MinValue, "Contrato não foi finalizado.").Validate();
            Assertion.IsFalse(vigente, "Contrato não foi finalizado.").Validate();
            
            #endregion
        }

        public virtual void Validate()
        {
            Assertion.NotNull(this.time, "Time não informado.").Validate();
            Assertion.NotNull(this.jogador, "Jogador não informado.").Validate();
            Assertion.GreaterThan(this.dataInicio, DateTime.MinValue, "Data inicio do contrato não foi informada.").Validate();
        }

        private void IniciarVigencia()
        {
            this.vigente = true;

            #region Pós-condições
            Assertion.IsTrue(vigente, "Contrato não está vigente.");
            #endregion
        }

        private void IniciarDataVigencia()
        {
            dataInicio = DateTime.Now;

            #region Pós-Condições
            Assertion.GreaterThan(dataInicio, DateTime.MinValue, "Data inicio do contrato não foi informada.").Validate();
            #endregion
        }

        private void FinalizarDataVigencia()
        {
            dataFinal = DateTime.Now;

            Assertion.GreaterThan(dataFinal, DateTime.MinValue, "Data final não foi informada.").Validate();
        }

        private void FinalizarVigencia()
        {
            this.vigente = false;
        }
    }
}
