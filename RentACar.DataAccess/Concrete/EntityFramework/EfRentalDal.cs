using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                IQueryable<RentalDetailDto> rentalDetails = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                    join c in context.Cars
                        on r.CarId equals c.Id
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join cs in context.Customers
                        on r.CustomerId equals cs.Id
                    join user in context.Users
                        on cs.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        CarId = c.Id,
                        RentalId = r.Id,
                        BrandId = c.BrandId,
                        BrandName = b.Name,
                        UserName = user.FirstName + " " + user.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return rentalDetails.ToList();
            }
        }
    }
}
