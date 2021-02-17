using Microsoft.Extensions.DependencyInjection;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;

namespace RentACar.Business
{
    /// <summary>
    /// Extension method for IoC Containers
    /// </summary>
    public static class ServiceCollector
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>()
                .AddScoped<IRentalService, RentalManager>()
                .AddScoped<ICustomerService, CustomerManager>()
                .AddScoped<ICarService, CarManager>()
                .AddScoped<IColorService, ColorManager>()
                .AddScoped<IBrandService, BrandManager>();

            services.AddScoped<IColorDal, EfColorDal>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<ICarDal, EfCarDal>()
            .AddScoped<IUserDal, EfUserDal>()
            .AddScoped<ICustomerDal, EfCustomerDal>()
            .AddScoped<IRentalDal, EfRentalDal>();

            return services;
        }
    }
}
