using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace RentACar.Core.Utilities.Interceptors
{
    /// <summary>
    /// Base attribute for especially class and methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
