using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.ExemploPuro.Framework
{
    public interface ISpecification
    {
        object Candidate { get; }

        bool IsSatisfied();

        ISpecification AND(ISpecification other);

        ISpecification and(ISpecification other);

        ISpecification OR(ISpecification other);

        ISpecification or(ISpecification other);

        ISpecification Not();

    }
 
}
