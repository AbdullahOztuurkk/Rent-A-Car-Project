using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Concrete.InMemory
{
    /// <summary>
    /// InMemory Car Data access class with some dummy data
    /// </summary>
    public class InMemoryCarDal:IEntityRepository<Car>,ICarDal
    {
        private List<Car> carList;
        public InMemoryCarDal()
        {
            carList=new List<Car>()
            {
                new Car(){ BrandId = 1,ColorId = 1,DailyPrice = 1000,Description = "Porsche Cayenne", ModelYear = 2002},
                new Car(){BrandId = 1,ColorId = 2,DailyPrice = 700,Description = "Porsche Panamera",ModelYear = 2009},
                new Car(){BrandId = 1,ColorId = 3,DailyPrice = 850,Description = "Porsche 911",ModelYear = 1963}
            };
        }
        public Car Get(int id)
        {
            return carList.Where(car=>car.Id==id).FirstOrDefault();
        }

        public void Add(Car entity)
        {
            carList.Add(entity);
        }

        public void Update(Car entity)
        {
            var currentCar = carList.Where(car => car.Id == entity.Id).FirstOrDefault();
            currentCar.ColorId = entity.ColorId;
            currentCar.BrandId = entity.BrandId;
            currentCar.DailyPrice = entity.DailyPrice;
            currentCar.Description = entity.Description;
            currentCar.ModelYear = entity.ModelYear;
        }

        public void Delete(Car entity)
        {
            carList.Remove(carList.Where(car => car.Id == entity.Id).FirstOrDefault());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return carList;
        }

        public void AddRange(List<Car> cars)
        {
            carList.AddRange(cars);
        }

        public List<GetCarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<GetCarImagesDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
