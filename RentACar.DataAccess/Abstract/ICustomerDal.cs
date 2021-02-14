using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
