using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac;
using RentACar.Business.DependencyRevolvers.Autofac;
using Autofac.Extensions.DependencyInjection;

namespace RentACar.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /*
         * Set default ioc container to autofac
         */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
