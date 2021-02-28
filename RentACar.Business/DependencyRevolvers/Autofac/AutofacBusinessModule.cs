using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.Security.JWT;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;

namespace RentACar.Business.DependencyRevolvers.Autofac
{
    /// <summary>
    /// Autofac dependency injection Module
    /// </summary>
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //Business injections
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<FileManager>().As<IFileProcess>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            //DataAccess injections
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();

            //General AOP Configuration
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
