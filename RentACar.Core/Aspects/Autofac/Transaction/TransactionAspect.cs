using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using RentACar.Core.Utilities.Interceptors;

namespace RentACar.Core.Aspects.Autofac.Transaction
{
    /// <summary>
    /// It can be applied to any rollback process. 
    /// </summary>
    class TransactionAspect :MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    scope.Complete();
                }
                //If any exception throw
                catch (System.Exception e)
                {
                    scope.Dispose();
                    throw new Exception(e.Message);
                }
                //exit and rollback the process
            }
        }
    }
}
