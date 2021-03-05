using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Core.CrossCuttingCorners.Caching;
using RentACar.Core.CrossCuttingCorners.Caching.Microsoft;
using RentACar.Core.Utilities.IoC;

namespace RentACar.Core.DependencyRevolvers
{
    /// <summary>
    /// Used dependencies in Core Layer in module
    /// </summary>
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<ICacheManager, MemoryCacheManager>();
        }
    }
}
