using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;
using DDD.Exemplopuro.Domain.Patrocinio;

namespace DDD.Exemplopuro.Domain.Comercial
{

    [Serializable]
    public class Patrocinador : IAggregateRoot<int>
    {
        private int id;
        private string nome;

        public virtual int Id
        {
            get { return this.id; }
        }

        public virtual string Nome
        {
            get { return nome; }
        }

        public virtual IList<ContratoPatrocinio> Patrocinados
        {
            get;
            set;
        }

        protected Patrocinador() { }

        public Patrocinador(string nome)
        {
            #region Pré-Condições
            Assertion.GreaterThan(nome, string.Empty, "Nome do patrocinador não informado.").Validate();
            #endregion

            Patrocinados = new List<ContratoPatrocinio>();
            this.nome = nome;

            #region Pós-Condições
            this.Validate();
            #endregion
        }

        public virtual void Validate()
        {
            Assertion.GreaterThan(nome, string.Empty, "Nome do patrocinador não informado.").Validate();
        }

        public virtual void AdicionarPatrocinado(ContratoPatrocinio patrocinado)
        {
            //Adicionar especificacao se patrocinado jah tem contrato vigente com este patrocinador
            #region Pré-Condições
            Assertion.NotNull(patrocinado, "Contrato patrocinio não informado.").Validate();
            patrocinado.Validate();
            #endregion

            this.Patrocinados.Add(patrocinado);

            #region Pós-Condições
            Assertion.IsTrue(Patrocinados.Contains(patrocinado), "Contrato patrocinio não atribuido corretamente.").Validate();
            #endregion
        }

        private CreditoPatrocinador CriarCredito(decimal valor, DateTime data, TipoCredito tipoCredito)
        {
            #region Pré-Condições
            Assertion.NotNull(tipoCredito, "Tipo crédito não informado.").Validate();
            Assertion.GreaterThan(data, DateTime.MinValue, "Data do crédito não informada.").Validate();
            Assertion.GreaterThan(valor, default(decimal), "valor não informado.").Validate();
            #endregion

            var credito = new CreditoPatrocinador(tipoCredito, data, valor);

            #region Pós-Condições
            credito.Validate();
            #endregion

            return credito;
        }


        private bool TemContratoCom(Patrocinado patrocinado)
        {
            #region Pré-Condições
            Assertion.NotNull(patrocinado, "Patrocinado não informado").Validate();
            Assertion.NotNull(this.Patrocinados, "Este patrocinador não tem patrocinados.").Validate();
            Assertion.GreaterThan(this.Patrocinados.Count, default(int), "Este patrocinador não tem patrocinados.").Validate();
            #endregion

            return this.Patrocinados.Where(p => p.Patrocinado == patrocinado && p.Vigente).Any();
        }

        public virtual void ContratarJogador(Patrocinado timeContratante, Patrocinado jogadorAContratar)
        {
            #region Pré-Condições
            Assertion.NotNull(timeContratante, "Time não informado.").Validate();
            Assertion.NotNull(jogadorAContratar, "Jogador não foi informado.").Validate();
            Assertion.IsTrue(this.TemContratoCom(timeContratante), "Este patrocinador não tem contrato com este time.").Validate();
            Assertion.IsTrue(this.TemContratoCom(jogadorAContratar), "Este patrocinador não tem contrato com este time").Validate();
            
            #endregion

            //Desfazer o contrato do jogador com o time atual.
            // this.FinalizarContratoAtualJogador(contratoAtualDoJogador);
            timeContratante.ContratarJogador(jogadorAContratar);
        }

        private bool EContratoAtualDoJogador(Patrocinado jogador)
        {
            //return this.Patrocinados.Where(p=> p.Patrocinado == jogador
            return true;
        }

        public virtual void ContratarJogador(Contrato contrato, Patrocinado timeComprador, Patrocinado TimeAReceber, Patrocinado jogadorAContratar)
        {
            #region Pré-Condições

            Assertion.NotNull(timeComprador, "Time comprador não informado.").Validate();
            Assertion.NotNull(TimeAReceber, "Time vendedor não informado.").Validate();
            Assertion.NotNull(jogadorAContratar, "Jogador não foi informado.").Validate();
            Assertion.IsTrue(this.TemContratoCom(timeComprador), "Este patrocinador não tem contrato com este time comprador.").Validate();
            Assertion.IsTrue(this.TemContratoCom(TimeAReceber), "Este patrocinador não tem contrato com este time vendedor.").Validate();
            Assertion.IsTrue(this.TemContratoCom(jogadorAContratar), "Este patrocinador não tem contrato com este time.").Validate();
            Assertion.IsTrue(timeComprador.SaldoPositivo(), "Time comprador deve ter saldo positivo para comprar.").Validate();

            #endregion

            TimeAReceber.ResindirContrato(contrato);
            timeComprador.ContratarJogador(jogadorAContratar);

            #region Pós-Condições

            Assertion.IsFalse(contrato.Vigente, "Contrato não foi finalizado.");

            #endregion
        }

     
    }
}
