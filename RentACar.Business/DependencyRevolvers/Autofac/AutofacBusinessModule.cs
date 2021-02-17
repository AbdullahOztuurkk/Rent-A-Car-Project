using Autofac;
using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;

namespace RentACar.Business.DependencyRevolvers.Autofac
{
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

            //DataAccess injections
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            //Db injection
            builder.RegisterType<RentACarContext>().As<DbContext>();
        }
    }
}
