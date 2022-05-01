using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        /// <summary>
        /// Metot çalıştıktan önce
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation)
        {

        }
        /// <summary>
        /// Metot çalıştıktan sonra
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation)
        {

        }
        /// <summary>
        /// Metot hata aldığında
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation, Exception exception)
        {

        }
        /// <summary>
        /// Metot başarılı olduğunda
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                if (invocation.ReturnValue is Task returnValueTask)
                {
                    returnValueTask.GetAwaiter().GetResult();
                }

                if (invocation.ReturnValue is Task task && task.Exception != null)
                {
                    throw task.Exception;
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
                OnAfter(invocation);
            }
          
        }
    }
}
