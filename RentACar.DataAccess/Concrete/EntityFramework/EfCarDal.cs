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
    public class EfCarDal:EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {
        /// <summary>
        /// Multiple add cars method
        /// </summary>
        /// <param name="cars"></param>
        public void AddRange(List<Car> cars)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.AddRange(cars);
            }
        }
        /// <summary>
        /// Get All details from car table
        /// </summary>
        /// <returns>Car object</returns>
        public List<GetCarDetailDto> GetCarDetails(Expression<Func<Car,bool>> filter=null)
        {
            using (RentACarContext context =new RentACarContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                    join brn in context.Brands
                        on car.BrandId equals brn.Id
                    join clr in context.Colors
                        on car.ColorId equals clr.Id
                    select new GetCarDetailDto()
                    {
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        CarName = car.Description,
                        ColorName = clr.Name,
                        BrandName = brn.Name,
                        Description = car.Description,
                        ImagePath = (from m in context.CarImages where m.CarId == car.Id select m.ImagePath).FirstOrDefault(),
                        IsRentable = !context.Rentals.Any(r => r.CarId == car.Id) || !context.Rentals.Any(r => r.CarId == car.Id && (r.ReturnDate == null || (r.ReturnDate.HasValue && r.ReturnDate > DateTime.Now)))
                    };
                return result.ToList();
            }
        }

        /// <summary>
        /// Get Car Images with filter
        /// </summary>
        /// <param name="filter">Expression For Car Class</param>
        /// <returns></returns>
        public List<GetCarImagesDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                    join brn in context.Brands
                        on car.BrandId equals brn.Id
                    join clr in context.Colors
                        on car.ColorId equals clr.Id
                    join crm in context.CarImages
                        on car.Id equals crm.CarId
                    select new GetCarImagesDto()
                    {
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        Description = car.Description,
                        ColorName = clr.Name,
                        BrandName = brn.Name,
                        ImagePath = crm.ImagePath,
                        CreatedDate = crm.CreatedDate,
                    };
                return result.ToList();
            }
        }
    }
}
