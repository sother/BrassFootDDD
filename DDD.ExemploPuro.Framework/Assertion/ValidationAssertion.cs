using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace DDD.ExemploPuro.Framework
{
    public class ValidationAssertion : Assertion 
    {
        protected object candidate;
        private List<string> messages;

        public List<string> Messages
        {
            get 
            {
                if (messages == null) messages = new List<string>();
                return messages; 
            }
        }

        public ValidationAssertion(object candidate, string message) : base(null, message) 
        {
            this.candidate = candidate;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        protected override bool HasMessage()
        {
            return Messages.Count > 0;
        }

        protected override void AddMessage(List<string> messages)
        {
            if (base.HasMessage())
            {
                messages.Add(this.Message);
            }

            if (HasMessage())
            {
                messages.AddRange(Messages);
            }
        }

        #region IsNullOrBlank
        /// <summary>
        /// Indica se texto é nulo ou vazio.
        /// </summary>
        /// <param name="str">Texto</param>
        /// <returns>Falso ou Verdadeiro</returns>
        protected bool IsNullOrBlank(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        #endregion 

        #region FindObjectInCollection
        /// <summary>
        /// Informa se Objeto Procurado foi encontrado na coleção informada.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto Procurado</typeparam>
        /// <param name="searchedObject">Objeto Procurado</param>
        /// <param name="collection">Coleção do Tipo informado</param>
        public bool FindObjectInCollection<P>(P searchedObject, IEnumerable<P> collection)
        {
            //collection.Any
            bool found = false;

            foreach (P obj in collection)
            {
                if (obj.Equals(searchedObject))
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
        #endregion

        #region Fail
        /// <summary>
        /// Adiciona mensagem de erro conforme condição.
        /// </summary>
        /// <param name="errorCondition">Condição de Erro</param>
        /// <param name="error">Mensagem de Erro</param>
        public void Fail(bool errorCondition, string error)
        {
            if (errorCondition)
            {
                this.Fail(error);
            }
        }

        public void Fail(string error)
        {
            this.Messages.Add(error);
        }

        #endregion Fail

        #region FailIfPattern

        public void FailIfPattern(string value, string pattern, string error)
        {
            if (string.IsNullOrEmpty(value)) return;
            if (string.IsNullOrEmpty(pattern)) throw new ApplicationException("RegexValidation: Padrão de validação obrigatório.");
            Regex exp = new Regex(pattern, RegexOptions.None);

            Fail(!exp.IsMatch(value), error);
        }

        #endregion

        #region FailIfNotPattern

        public void FailIfNotPattern(string value, string pattern, string error)
        {
            if (string.IsNullOrEmpty(value)) return;
            if (string.IsNullOrEmpty(pattern)) throw new ApplicationException("RegexValidation: Padrão de validação obrigatório.");
            Regex exp = new Regex(pattern, RegexOptions.None);

            Fail(!exp.IsMatch(value), error);
        }

        #endregion

        #region FailIfContains
        /// <summary>
        /// Adiciona mensagem de Erro caso Objeto Procurado seja encontrado na coleção informada.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto Procurado</typeparam>
        /// <param name="searchedObject">Objeto Procurado</param>
        /// <param name="collection">Coleção do Tipo informado</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfContains<P>(P searchedObject, IEnumerable<P> collection, string error)
        {
            bool found = FindObjectInCollection<P>(searchedObject, collection);
            Fail(found, error);
        }

        #endregion FailIfContains

        #region FailIfNotContains
        /// <summary>
        /// Adiciona mensagem de Erro caso Objeto Procurado NÃO seja encontrado na coleção informada.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto Procurado</typeparam>
        /// <param name="searchedObject">Objeto Procurado</param>
        /// <param name="collection">Coleção do Tipo informado</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNotContains<P>(P searchedObject, IEnumerable<P> collection, string error)
        {
            bool found = FindObjectInCollection<P>(searchedObject, collection);
            Fail(!found, error);
        }

        #endregion FailIfNotContains

        #region FailIfNull
        /// <summary>
        /// Adiciona mensagem de erro caso objeto seja nulo.
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNull(object obj, string error)
        {
            Fail(obj == null, error);
        }
        #endregion FailIfNull

        #region FailIfNotNull
        /// <summary>
        /// Adiciona mensagem de erro caso objeto NÃO seja nulo.
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNotNull(object obj, string error)
        {
            Fail(obj != null, error);
        }
        #endregion FailIfNotNull

        #region FailIfNullOrBlank
        /// <summary>
        /// Adiciona mensagem de Erro caso texto seja nulo ou vazio.
        /// </summary>
        /// <param name="str">Texto</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNullOrBlank(string str, string error)
        {
            Fail(IsNullOrBlank(str), error);
        }
        #endregion FailIfNullOrBlank

        #region FailIfNotNullOrBlank
        /// <summary>
        /// Adiciona mensagem de Erro caso texto NÃO seja nulo ou vazio.
        /// </summary>
        /// <param name="str">Texto</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNotNullOrBlank(string str, string error)
        {
            Fail(!IsNullOrBlank(str), error);
        }
        #endregion

        #region FailIfExceedMaxLength
        /// <summary>
        /// Adiciona mensagem de erro caso texto ultrapasse tamanho máximo
        /// </summary>
        /// <param name="str">Texto</param>
        /// <param name="maxLength">Tamanho máximo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfExceedMaxLength(string str, int maxLength, string error)
        {
            if (str != null)
            {
                Fail(str.Length > maxLength, error);
            }
        }
        #endregion FailIfExceedMaxLength

        #region FailIfNotMimLength
        /// <summary>
        /// Adiciona mensagem de erro caso texto ultrapasse tamanho máximo
        /// </summary>
        /// <param name="str">Texto</param>
        /// <param name="minLength">Tamanho mínimo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNotMimLength(string str, int minLength, string error)
        {
            if (str != null)
            {
                Fail(str.Length < minLength, error);
            }
        }
        #endregion FailIfNotMimLength

        #region FailIfLessThanMimValue
        /// <summary>
        /// Adiciona mensagem de erro caso número não atinja valor mínimo.
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="minValue">Valor Mínimo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfLessThanMimValue(int numero, int minValue, string error)
        {
            Fail(numero < minValue, error);
        }

        public void FailIfLessThanMimValue(long numero, long minValue, string error)
        {
            Fail(numero < minValue, error);
        }

        public void FailIfLessThanMimValue(long numero, int minValue, string error)
        {
            Fail(numero < minValue, error);
        }

        public void FailIfLessThanMimValue(decimal numero, decimal minValue, string error)
        {
            Fail(numero < minValue, error);
        }

        public void FailIfLessThanMimValue(double numero, double minValue, string error)
        {
            Fail(numero < minValue, error);
        }
        #endregion FailIfExceedMaxValue

        #region FailIfExceedMaxValue
        /// <summary>
        /// Adiciona mensagem de erro caso número exceda valor máximo.
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="maxValue">Valor Mínimo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfExceedMaxValue(int numero, int maxValue, string error)
        {
            Fail(numero > maxValue, error);
        }

        public void FailIfExceedMaxValue(long numero, long maxValue, string error)
        {
            Fail(numero > maxValue, error);
        }

        public void FailIfExceedMaxValue(long numero, int maxValue, string error)
        {
            Fail(numero > maxValue, error);
        }

        public void FailIfExceedMaxValue(decimal numero, decimal maxValue, string error)
        {
            Fail(numero > maxValue, error);
        }

        public void FailIfExceedMaxValue(double numero, double maxValue, string error)
        {
            Fail(numero > maxValue, error);
        }
        #endregion FailIfExceedMaxValue

        #region FailIfNonPositive
        /// <summary>
        /// Adiciona mensagem de erro caso número nào seja positivo.
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNonPositive(int numero, string error)
        {
            Fail(numero <= 0, error);
        }

        public void FailIfNonPositive(short numero, string error)
        {
            Fail(numero <= 0, error);
        }

        public void FailIfNonPositive(long numero, string error)
        {
            Fail(numero <= 0, error);
        }

        public void FailIfNonPositive(decimal numero, string error)
        {
            Fail(numero <= 0, error);
        }

        public void FailIfNonPositive(double numero, string error)
        {
            Fail(numero <= 0, error);
        }
        #endregion FailIfNonPositive

        #region FailIfNegative
        /// <summary>
        /// Adiciona mensagem de erro caso número seja negativo.
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNegative(int numero, string error)
        {
            Fail(numero < 0, error);
        }

        public void FailIfNegative(long numero, string error)
        {
            Fail(numero < 0, error);
        }

        public void FailIfNegative(decimal numero, string error)
        {
            Fail(numero < 0, error);
        }

        public void FailIfNegative(double numero, string error)
        {
            Fail(numero < 0, error);
        }
        #endregion FailIfNegative

        #region FailIfZero
        /// <summary>
        /// Adiciona mensagem de erro caso número seja Zero.
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfZero(int numero, string error)
        {
            Fail(numero == 0, error);
        }

        public void FailIfZero(long numero, string error)
        {
            Fail(numero == 0, error);
        }

        public void FailIfZero(decimal numero, string error)
        {
            Fail(numero == 0, error);
        }

        public void FailIfZero(double numero, string error)
        {
            Fail(numero == 0, error);
        }
        #endregion FailIfZero

        #region FailIfGreaterThan
        /// <summary>
        /// Falha se for Maior que o Máximo
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="maximo">Máximo</param>
        /// <param name="error">Mensagem de Erro</param>
        /// <param name="errors">Lista de Erros</param>
        public void FailIfGreaterThan(int numero, int maximo, string error)
        {
            Fail(numero > maximo, error);
        }

        public void FailIfGreaterThan(long numero, long maximo, string error)
        {
            Fail(numero > maximo, error);
        }

        public void FailIfGreaterThan(decimal numero, decimal maximo, string error)
        {
            Fail(numero > maximo, error);
        }

        public void FailIfGreaterThan(double numero, double maximo, string error)
        {
            Fail(numero > maximo, error);
        }
        #endregion FailIfGreaterThan

        #region FailIfLessThan
        /// <summary>
        /// Falha se for Menor que o Mínimo
        /// </summary>
        /// <param name="numero">Número</param>
        /// <param name="minimo">Mínimo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfLessThan(int numero, int minimo, string error)
        {
            Fail(numero < minimo, error);
        }

        public void FailIfLessThan(long numero, long minimo, string error)
        {
            Fail(numero < minimo, error);
        }

        public void FailIfLessThan(decimal numero, decimal minimo, string error)
        {
            Fail(numero < minimo, error);
        }

        public void FailIfLessThan(double numero, double minimo, string error)
        {
            Fail(numero < minimo, error);
        }
        #endregion FailIfLessThan

        #region FailIfEquals
        /// <summary>
        /// Adiciona mensagem de erro caso de não igualdade do valor informado
        /// e valor modelo.
        /// </summary>
        /// <param name="str">Valor Informado</param>
        /// <param name="strModelo">Valor Modelo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfEquals(string str, string strModelo, string error)
        {
            Fail(str == strModelo, error);
        }

        public void FailIfEquals(int numero, int numeroModelo, string error)
        {
            Fail(numero == numeroModelo, error);
        }

        public void FailIfEquals(long numero, long numeroModelo, string error)
        {
            Fail(numero == numeroModelo, error);
        }

        public void FailIfEquals(decimal numero, decimal numeroModelo, string error)
        {
            Fail(numero == numeroModelo, error);
        }

        public void FailIfEquals(double numero, double numeroModelo, string error)
        {
            Fail(numero == numeroModelo, error);
        }
        #endregion FailIfEquals

        #region FailIfNotEquals
        /// <summary>
        /// Adiciona mensagem de erro caso de igualdade do valor informado
        /// e valor modelo.
        /// </summary>
        /// <param name="str">Valor Informado</param>
        /// <param name="strModelo">Valor Modelo</param>
        /// <param name="error">Mensagem de Erro</param>
        public void FailIfNotEquals(string str, string strModelo, string error)
        {
            Fail(str != strModelo, error);
        }

        public void FailIfNotEquals(int numero, int numeroModelo, string error)
        {
            Fail(numero != numeroModelo, error);
        }

        public void FailIfNotEquals(decimal numero, decimal numeroModelo, string error)
        {
            Fail(numero != numeroModelo, error);
        }

        public void FailIfNotEquals(double numero, double numeroModelo, string error)
        {
            Fail(numero != numeroModelo, error);
        }
        #endregion FailIfNotEquals

        #region FailIfStringNotNumeric

        public void FailIfStringNotNumeric(string str, string error)
        {
            if (string.IsNullOrEmpty(str)) return;

            Regex pattern = new Regex(@"^(-)?\d+(\" + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator + @"\d\d)?$");

            if (!pattern.IsMatch(str))
            {
                this.Fail(true, error);
            }
        }

        #endregion FailIfStringNotNumeric

        #region FailIfInRange
        /// <summary>
        /// 
        /// </summary>
        public void FailIfInRange(object value, object start, object end, string error)
        {
            if (value == null) return;
            IComparable compare = value as IComparable;

            bool fail = !(compare.CompareTo(start) >= 0 && compare.CompareTo(end) <= 0);

            Fail(fail, error);
        }


        #endregion FailIfInRange

        #region FailIfNotCep

        public void FailIfNotCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) return;

            Regex pattern = new Regex(@"(^\d{5}-\d{3}$)|(^\d{8}$)");
            if (!pattern.IsMatch(cep))
            {
                Fail("CEP inválido.");
            }
        }

        #endregion

    }
}
