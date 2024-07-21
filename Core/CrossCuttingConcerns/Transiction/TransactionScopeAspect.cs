using Castle.DynamicProxy;
using Core.Utilites.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.CrossCuttingConcerns.Transiction
{
    public class TransactionScopeAspect: MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();// Metodun orjinalını çalıştırır 
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {

                   transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
