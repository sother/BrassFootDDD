using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain
{
    public enum TipoPatrocinadoEnum
    {
        jogador = 1,
        time = 2
    }

    //public interface  Patrocinado 
    //{
    //    string Nome
    //    {
    //        get;
    //        set;
    //    }


    //    ICollection<CreditoPatrocinador> Creditos
    //    {
    //        get;
    //        set;
    //    }

    //    TipoPatrocinadoEnum TipoPatrocinado
    //    {
    //        get;
    //        set;
    //    }

    //      void ReceberPagamento(CreditoPatrocinador credito);


    //}

    public abstract class Patrocinado : IAggregateRoot<int>
    {
        private int id;
        private List<CreditoPatrocinador> creditos;
        private TipoPatrocinadoEnum tipoPatrocinado;
        private ICollection<Contrato> contratos;

        private string nome;

        public virtual string Nome
        {
            get { return nome; }
        }

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }

        public virtual ICollection<CreditoPatrocinador> Creditos
        {
            get { return this.creditos ?? (creditos = new List<CreditoPatrocinador>()); }
        }

        public virtual ICollection<Contrato> Contratos
        {
            get { return contratos ?? (contratos = new List<Contrato>()); }
        }

        public virtual TipoPatrocinadoEnum TipoPatrocinado
        {
            get { return tipoPatrocinado; }
        }

        protected Patrocinado() { }
        public Patrocinado(string nome)
        {
            #region Pré-Condições
            Assertion.GreaterThan(nome, string.Empty, "Nome do patrocinado não informado.").Validate();
            #endregion

            this.nome = nome;

            #region Pós-condições
            this.Validate();
            #endregion
        }

        public virtual void AdicionarContrato(Contrato contrato)
        {
            Assertion.NotNull(contrato, "Contrato inválido.").Validate();

            //Tem que ser diferente entre jogador e TIme
            //Time pode ter varios Contrato com jogadores
            //E jogador pode ter apenas um contrato com o time
            this.Contratos.Add(contrato);
        }

        protected virtual void ReceberPagamento(CreditoPatrocinador credito)
        {
            #region Pré-Condições
            credito.Validate();
            #endregion

            Creditos.Add(credito);

            #region Pós-Condições
            Assertion.IsTrue(Creditos.Contains(credito), "Crédito não foi atribuido corretamente.").Validate();
            #endregion
        }

        public virtual void Validate()
        {
            Assertion.GreaterThan(nome, string.Empty, "Nome do patrocinado não informado.").Validate();
        }

        protected bool MeuContrato(Contrato contrato)
        {
            return this.Contratos.Where(c => c == contrato).Any();
        }

        public abstract IList<Patrocinado> ObterTimes();
        public abstract IList<Patrocinado> ObterJogadores();
        public abstract void ContratarJogador(Patrocinado jogadorr);
        public  abstract bool TemVinculo();

        //TODO VER PQ ESTA PUBLIC
        public abstract void ResindirContrato(Contrato contrato);        

        public virtual bool SaldoPositivo()
        {
            return Assertion.GreaterThan(Creditos.Select(c => c.Valor).Sum(), default(decimal), "Saldo do time deve ser positivo para contratar Jogadores").IsValid();
        }
    }
}
