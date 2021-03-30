using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        public List<CustomerDetailDto> GetCustomerList(Expression<Func<CustomerDetailDto, bool>> filter = null);
    }
}
