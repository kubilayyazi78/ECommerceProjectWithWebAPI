using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
    public class RemoveCache : MethodInterception
    {
        private readonly string _methodName;
        private readonly ICacheService _cacheService;

        public RemoveCache(string methodName)
        {
            _methodName = methodName;
            _cacheService=(ICacheService)Core.Utilities.Helpers.HttpContext.Current.RequestServices.GetService(
                typeof(ICacheService));
        }

        public override void Intercept(IInvocation invocation)
        {
            _cacheService.Remove(_methodName);
        }
    }
}
