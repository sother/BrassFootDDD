using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.ExemploPuro.Framework
{
    public class andAssertion : Assertion
    {
        private IAssertion one;
        private IAssertion other;

        public andAssertion(IAssertion one, IAssertion other)
        {
            this.one = one;            
            this.other = other;
        }

        public override bool IsValid()
        {
            return one.IsValid() & other.IsValid();
        }

        public override void DoValidation(List<string> messages)
        {
            one.DoValidation(messages);
            other.DoValidation(messages);
        }
    }
}
