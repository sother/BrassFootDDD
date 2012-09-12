using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.ExemploPuro.Framework
{
    public class AND_Specification : CompositeSpecification
    {
        private ISpecification one;
        private ISpecification other;

        public AND_Specification(ISpecification one, ISpecification other)
        {
            this.one = one;            
            this.other = other;
        }

        public override bool IsSatisfied()
        {
            return one.IsSatisfied() && other.IsSatisfied();
        }
    }
}
