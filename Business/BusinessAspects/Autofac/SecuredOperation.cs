using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Core.Extensions;
using Business.Constans;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;  // JWT ile yaptığımız isteğe karşılık herkese farklı bir istek oluşturur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //productService = ServiceTool.ServiceProvider.GetService<IProductService>();
            /* Aspect çalıştığımız için injection yapmak isterken  zincir dışında kalıyoruz, oluşturduğumuz ServiceTool bu konuda bize bi üst satırda ki gibi yardımcı oluyor. */
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
