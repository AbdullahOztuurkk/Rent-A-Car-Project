using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Business.Constants;
using RentACar.Core.Extensions;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.IoC;

namespace RentACar.Business.BusinessAspects
{
    /// <summary>
    /// General Authorize Aspect
    /// </summary>
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }
        //Check user permission
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
