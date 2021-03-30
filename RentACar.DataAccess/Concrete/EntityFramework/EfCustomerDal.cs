using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerList(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                IQueryable<CustomerDetailDto> customerDetails = from u in context.Users
                    join c in context.Customers
                        on u.Id equals c.UserId
                    join r in context.Rentals
                        on c.Id equals r.CustomerId
                    join cr in context.Cars
                        on r.CarId equals cr.Id
                    select new CustomerDetailDto
                    {
                        UserId = u.Id,
                        CustomerId = c.Id,
                        CarId = cr.Id,
                        CustomerName = u.FirstName + " " + u.LastName,
                    };
                return filter == null ? customerDetails.ToList() : customerDetails.Where(filter).ToList();
            }
        }
    }
}
