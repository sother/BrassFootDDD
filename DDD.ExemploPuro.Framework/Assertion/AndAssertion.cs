using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.ExemploPuro.Framework
{
    public class AndAssertion : Assertion
    {
        private IAssertion one;
        private IAssertion other;

        public AndAssertion(IAssertion one, IAssertion other)
        {
            this.one = one;            
            this.other = other;
        }

        public override bool IsValid()
        {
            return one.IsValid() && other.IsValid();
        }

        public override void DoValidation(List<string> messages)
        {
            List<string> oneErrors = new List<string>();
            one.DoValidation(oneErrors);

            bool isValid = oneErrors.Count == 0;

            if (!isValid)
            {
                messages.AddRange(oneErrors);
                return;
            }

            other.DoValidation(messages);
        }
    }
}
