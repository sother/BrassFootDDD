using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ExemploPuro.Framework
{
    public class CompositeSpecification : ISpecification
    {
        protected object candidate;
        public object Candidate 
        {
            get
            {
                return candidate;
            }
        }

        public virtual bool IsSatisfied()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ISpecification AND(ISpecification other)
        {
            return new AND_Specification(this, other);
        }

        public ISpecification and(ISpecification other)
        {
            return new and_Specification(this, other);
        }

        public ISpecification OR(ISpecification other)
        {
            return new OR_Specification(this, other);
        }

        public ISpecification or(ISpecification other)
        {
            return new or_Specification(this, other);
        }

        public ISpecification Not()
        {
            return new Not_Specification(this);
        }

        #region Construtores Estáticos

        public static ISpecification NotNull(object candidate)
        {
            return new LambdaSpecification(() => candidate != null);
        }

        public static ISpecification Null(object candidate)
        {
            return new LambdaSpecification(() => candidate == null);
        }

        public static ISpecification AreEquals(object candidate1, object candidate2)
        {
            return new LambdaSpecification(() => (candidate1 == null && candidate2 == null) || (candidate1 != null && candidate1.Equals(candidate2)));
        }

        public static ISpecification GreaterThan(IComparable candidate1, IComparable candidate2)
        {
            return new LambdaSpecification(() => (candidate1 != null && candidate1.CompareTo(candidate2)>0));
        }

        public static ISpecification EqualsOrGreaterThan(IComparable candidate1, IComparable candidate2)
        {
            return new LambdaSpecification(() => (candidate1 != null && candidate1.CompareTo(candidate2) >= 0));
        }

        public static ISpecification LessThan(IComparable candidate1, IComparable candidate2)
        {
            return new LambdaSpecification(() => (candidate1 != null && candidate1.CompareTo(candidate2) < 0));
        }

        public static ISpecification EqualsOrLessThan(IComparable candidate1, IComparable candidate2)
        {
            return new LambdaSpecification(() => (candidate1 != null && candidate1.CompareTo(candidate2) <= 0));
        }
        
        public static ISpecification Contains<T>(ICollection<T> container, object candidate)
        {
            return new LambdaSpecification(() => container.Contains((T)candidate));
        }

        public static ISpecification InRange(IComparable candidate, IComparable minimo, IComparable maximo)
        {
            return EqualsOrGreaterThan(candidate, minimo).AND(EqualsOrLessThan(candidate,maximo));
        }

        #endregion


    }
 
}
