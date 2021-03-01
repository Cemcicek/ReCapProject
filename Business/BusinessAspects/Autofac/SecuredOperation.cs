using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Castle.DynamicProxy;
using Core.Extensions;
using Business.Constants;
using System;
using Core.Utilites.Interceptors;
using Core.Utilites.IoC;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        public string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
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
            throw new Exception(Message.AuthorizationDenied);
        }
    }
}