using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.ExemploPuro.Framework
{
    public class NotAssertion : Assertion
    {
        private IAssertion wrapped;

        //public NotAssertion(IAssertion assertion) : base(assertion.Candidate, assertion.Message)
        public NotAssertion(IAssertion assertion) : base(assertion.Specification, assertion.Message)
        {
            wrapped = assertion;
        }

        public override bool IsValid()
        {
            return !wrapped.IsValid();
        }

    }
}
