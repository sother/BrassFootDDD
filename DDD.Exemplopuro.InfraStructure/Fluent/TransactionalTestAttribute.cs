using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Laos;

namespace DDD.Exemplopuro.InfraStructure
{
    [Serializable]
    public class TransactionalTestAttribute : PostSharp.Laos.OnMethodBoundaryAspect
    {
        [ThreadStatic]
        private static Stack<ITransactionManager> scopes;

        public Boolean IsNew { get; set; }
        public Boolean ReadOnly { get; set; }
        public Boolean NeverCommit { get; set; }

        public TransactionalTestAttribute()
        {
            AspectPriority = 2;
            IsNew = false;
            ReadOnly = false;
            NeverCommit = false;
        }

        public override void OnEntry(MethodExecutionEventArgs e)
        {
            base.OnEntry(e);

            if (scopes == null)
                scopes = new Stack<ITransactionManager>();

            TransactionModeEnum transactionMode = IsNew || ReadOnly ? TransactionModeEnum.New : TransactionModeEnum.Inherits;

            var transactionManager = new TransactionManagerFluent();

            transactionManager.Initialize();

            scopes.Push(transactionManager);
        }

        public override void OnException(MethodExecutionEventArgs e)
        {
            base.OnException(e);

            scopes.Peek().VoteRollBack();
        }

        public override void OnSuccess(MethodExecutionEventArgs e)
        {
            base.OnSuccess(e);
            scopes.Peek().VoteRollBack();
        }

        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
            base.OnExit(eventArgs);
            scopes.Peek().VoteRollBack();
            scopes.Pop().Dispose();
        }
    }
}
