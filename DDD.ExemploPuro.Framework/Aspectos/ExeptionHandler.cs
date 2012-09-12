using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;
using System.Reflection;
using System.Web;

namespace DDD.ExemploPuro.Framework.Aspectos
{
    

    [Serializable]
    public class eSimExceptionCatcherAttribute : OnExceptionAspect
    {
        public override Type GetExceptionType(MethodBase method)
        {
            return typeof(ApplicationException);
        }

        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            //var exceptionHandler = DIContainer.GetInstance<IExceptionHandler>();

            //exceptionHandler.AddMessage(eventArgs.Exception);
            //exceptionHandler.HandleException();

            //eventArgs.FlowBehavior = FlowBehavior.Return;
        }
    }
}
