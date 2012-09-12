using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.ExemploPuro.Framework
{
    public class OrAssertion : Assertion
    {
        private IAssertion one;
        private IAssertion other;

        public OrAssertion(IAssertion one, IAssertion other)
        {
            this.one = one;            
            this.other = other;
        }

        public override bool IsValid()
        {
            return one.IsValid() || other.IsValid();
        }

        public override void DoValidation(List<string> messages)
        {
            bool isValid = one.IsValid();

            if (isValid)
                return;
            else
                messages.Add(one.Message);

            other.DoValidation(messages);
        }
    }
}
