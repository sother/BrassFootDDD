using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDD.ExemploPuro.Framework;

namespace DDD.Exemplopuro.Domain.Comercial
{
    [Serializable]
    public class ContratoPatrocinio : IAggregateRoot<int>
    {
        private int id;
        private int mesesDeContrato;
        private decimal valorBaseBonus;
        private decimal valorBaseSalario;
        private decimal valorBaseDireitoDeImagem;
        private DateTime? dataInicio;
        private DateTime? dataFinal;
        private bool vigente;
        
        private Patrocinado patrocinado;

        public virtual int Id
        {
            get
            {
                return this.id;
            }
        }

        public virtual int MesesDeContrato
        {
            get { return mesesDeContrato; }
        }

        public virtual decimal ValorBaseBonus
        {
            get { return valorBaseBonus; }
        }

        public virtual decimal ValorBaseSalario
        {
            get { return valorBaseSalario; }
        }

        public virtual decimal ValorBaseDireitoDeImagem
        {
            get { return valorBaseDireitoDeImagem; }
        }

        public virtual Patrocinado Patrocinado
        {
            get { return patrocinado; }
        }

        public virtual DateTime? DataInicio
        {
            get { return dataInicio; }
        }

        public virtual DateTime? DataFinal
        {
            get { return dataFinal; }
        }
        public virtual bool Vigente
        {
            get { return vigente; }
        }

        protected ContratoPatrocinio() { }

        public ContratoPatrocinio(int mesesDeContrato, decimal valorBaseBonus, decimal valorBaseSalario, decimal valorBaseDireitoDeImagem, Patrocinado patrocinado)
        {
            #region Pré-Condições
            IAssertion mesesDeContratoInformado = Assertion.GreaterThan(mesesDeContrato, default(int), "Não fora informados meses de contrato.");
            IAssertion valorBaseBonusInformado = Assertion.GreaterThan(valorBaseBonus, default(decimal), "Não foi informado valor base bonûs.");
            IAssertion valorBaseSalarioInformado = Assertion.GreaterThan(valorBaseSalario, default(decimal), "Não foi informado valor base salario.");
            IAssertion valorBaseDireitoDeImagemInformado = Assertion.GreaterThan(valorBaseDireitoDeImagem, default(decimal), "Não foi informado valor base direito de imagem.");
            IAssertion patrocinadoInformado = Assertion.NotNull(patrocinado, "Não foi informado um patrocinado.");

            mesesDeContratoInformado.and(valorBaseBonusInformado).and(valorBaseSalarioInformado).and(valorBaseDireitoDeImagemInformado).and(patrocinadoInformado).Validate();
            
            #endregion


            this.mesesDeContrato = mesesDeContrato;
            this.valorBaseBonus = valorBaseBonus;
            this.valorBaseDireitoDeImagem = valorBaseDireitoDeImagem;
            this.valorBaseSalario = valorBaseSalario;
            this.InformarPatrocinado(patrocinado);
            IniciarDataVigencia();
            IniciarVigencia();

            #region Pós-Condições
            this.Validate();
            #endregion
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

        private void InformarPatrocinado(Patrocinado patrocinado)
        {
            #region Pré-Condições
            Assertion.NotNull(patrocinado, "Patrocinado não informado.").Validate();
            #endregion

            this.patrocinado = patrocinado;

            #region Pós-Condições
            Assertion.Equals(this.patrocinado, patrocinado, "Patrocinado não foi informado corretamente").Validate();
            #endregion
        }

        public virtual void Validate()
        {
            IAssertion mesesDeContratoInformado = Assertion.GreaterThan(mesesDeContrato, default(int), "Não fora informados meses de contrato.");
            IAssertion valorBaseBonusInformado = Assertion.GreaterThan(valorBaseBonus, default(decimal), "Não foi informado valor base bonûs.");
            IAssertion valorBaseSalarioInformado = Assertion.GreaterThan(valorBaseSalario, default(decimal), "Não foi informado valor base salario.");
            IAssertion valorBaseDireitoDeImagemInformado = Assertion.GreaterThan(valorBaseDireitoDeImagem, default(decimal), "Não foi informado valor base direito de imagem.");
            IAssertion patrocinadoInformado = Assertion.NotNull(patrocinado, "Não foi informado um patrocinado.");

            mesesDeContratoInformado.and(valorBaseBonusInformado).and(valorBaseSalarioInformado).and(valorBaseDireitoDeImagemInformado).and(patrocinadoInformado).Validate();

        }


    }
}
