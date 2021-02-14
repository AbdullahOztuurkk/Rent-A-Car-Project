using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
    }
}
