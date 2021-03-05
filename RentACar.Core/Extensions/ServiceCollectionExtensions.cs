using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Core.Utilities.IoC;

namespace RentACar.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add different modules to ServiceCollection
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="modules">Any Core Module</param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyRevolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var coreModule in modules)
            {
                coreModule.Load(services);
            }

            return ServiceTool.Create(services);
        }
}
}
