using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.IoC;

namespace RentACar.Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        /* Set expected interval kind of seconds */
        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        /* Start the stopwatch before running the method */
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        /*Reset the stopwatch when method worked and print performance status for specified interval*/
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
