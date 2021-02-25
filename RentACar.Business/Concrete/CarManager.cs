using System;
using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Business.Validation.FluentValidation;
using RentACar.Core.Aspects.Autofac;
using RentACar.Core.Utilities.FluentValidation;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal cardal;

        public CarManager(ICarDal cardal)
        {
            //Constructor Injection
            this.cardal = cardal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //CheckValidator.Validate(new CarValidator(), car);
            cardal.Add(car);
            return new SuccessResult(Messages.Add_Message(typeof(Car).Name));
        }

        public IResult AddRange(List<Car> cars)
        {
            cardal.AddRange(cars);
            return new SuccessResult(Messages.Multiple_Add_Message(typeof(Car).Name));
        }

        public IResult Update(Car car)
        {
            cardal.Update(car);
            return new SuccessResult(Messages.Update_Message(typeof(Car).Name));
        }

        public IResult Delete(int id)
        {
            cardal.Delete(GetById(id).Data);
            return new SuccessResult(Messages.Delete_Message(typeof(Car).Name));
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = cardal.Get(id);
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = cardal.GetAll();
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByModelYear(int ModelYear)
        {
            var result = cardal.GetAll(car => car.ModelYear == DateTime.UtcNow.Year);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByDailyPrice(int price)
        {
            var result = cardal.GetAll(car => car.DailyPrice == price);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetByDescription(string description)
        {
            var result= cardal.GetAll(car => car.Description.Contains(description));
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<GetCarImagesDto>> GetAllImagesById(int id)
        {
            var result = cardal.GetCarImageDetails(car => car.Id == id);
            return new SuccessDataResult<List<GetCarImagesDto>>(result);
        }
    }
}
