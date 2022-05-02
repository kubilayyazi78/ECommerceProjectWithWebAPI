using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _methodName;
        private readonly ICacheService _cacheService;

        public CacheRemoveAspect(string methodName)
        {
            _methodName = methodName;
            _cacheService = (ICacheService)Core.Utilities.Helpers.HttpContext.Current.RequestServices.GetService(
                typeof(ICacheService));
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.Remove($"Business.Abstract.{_methodName}()");
        }
    }
}