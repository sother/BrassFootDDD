using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DDD.ExemploPuro.Framework
{
    public class Assertion : IAssertion
    {
        #region Properties

        protected string message;
        public virtual string Message
        {
            get
            {
                if (message == null) return string.Empty;
                return message;
            }
            private set
            {
                message = value;
            }
        }

        public ISpecification Specification { get; private set; }

        private bool HasHttpContext
        {
            get
            {
                return HttpContext.Current != null;
            }
        }

        #endregion

        #region Constructor

        public Assertion() { }
        protected Assertion(ISpecification specification, string message)
        {
            this.Specification = specification;
            this.Message = message;
        }

        #endregion

        #region Methods

        public virtual void Validate()
        {
            List<string> messages = new List<string>();

            this.DoValidation(messages);

            if (messages.Count > 0)
            {
                DispararMensagens(messages);
            }
        }

        private static void DispararMensagens(List<string> messages)
        {
            StringBuilder errorMessages = new StringBuilder();
            messages.ForEach(m => errorMessages.Append(m));
            throw new ApplicationException(errorMessages.ToString());
        }

        public virtual void DoValidation(List<string> messages)
        {
            if (!IsValid())
                this.AddMessage(messages);
        }

        public virtual bool IsValid()
        {
            return Specification.IsSatisfied();
        }

        protected virtual bool HasMessage()
        {
            return !string.IsNullOrEmpty(Message);
        }

        protected virtual void AddMessage(List<string> messages)
        {
            if (HasMessage())
                messages.Add(Message);
        }

        public IAssertion AND(IAssertion other)
        {
            return new AndAssertion(this, other);
        }

        public IAssertion and(IAssertion other)
        {
            return new andAssertion(this, other);
        }

        public IAssertion OR(IAssertion other)
        {
            return new OrAssertion(this, other);
        }

        public IAssertion or(IAssertion other)
        {
            return new orAssertion(this, other);
        }

        public IAssertion Not()
        {
            return new NotAssertion(this);
        }

        #endregion

        #region Contrutores Estáticos

        public static IAssertion NotNull(object candidate, string message)
        {
            return new Assertion(CompositeSpecification.NotNull(candidate), message);
        }

        public static IAssertion Null(object candidate, string message)
        {
            return new Assertion(CompositeSpecification.Null(candidate), message);
        }

        public static IAssertion Equals(object candidate1, object candidate2, string message)
        {
            return new Assertion(CompositeSpecification.AreEquals(candidate1, candidate2), message);
        }

        public static IAssertion GreaterThan(IComparable candidate1, IComparable candidate2, string message)
        {
            return new Assertion(CompositeSpecification.GreaterThan(candidate1, candidate2), message);
        }

        public static IAssertion EqualsOrGreaterThan(IComparable candidate1, IComparable candidate2, string message)
        {
            return new Assertion(CompositeSpecification.EqualsOrGreaterThan(candidate1, candidate2), message);
        }

        public static IAssertion LessThan(IComparable candidate1, IComparable candidate2, string message)
        {
            return new Assertion(CompositeSpecification.LessThan(candidate1, candidate2), message);
        }

        public static IAssertion EqualsOrLessThan(IComparable candidate1, IComparable candidate2, string message)
        {
            return new Assertion(CompositeSpecification.EqualsOrLessThan(candidate1, candidate2), message);
        }

        public static IAssertion LambdaAssertion(Func<bool> lambda, string message)
        {
            return new Assertion(new LambdaSpecification(lambda), message);
        }

        public static IAssertion IsTrue(bool condition, string message)
        {
            return new Assertion(new LambdaSpecification(() => condition), message);
        }

        public static IAssertion IsFalse(bool condition, string message)
        {
            return new Assertion(new LambdaSpecification(() => !condition), message);
        }

        public static IAssertion ContainsAssertion<T>(ICollection<T> container, object candidate, string message)
        {
            return new Assertion(CompositeSpecification.Contains<T>(container, candidate), message);
        }

        public static IAssertion InRange(IComparable candidate, IComparable minimo, IComparable maximo, string message)
        {
            return new Assertion(CompositeSpecification.InRange(candidate, minimo, maximo), message);
        }

        #endregion
    }
}