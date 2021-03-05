using System;
using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.BusinessAspects;
using RentACar.Business.Constants;
using RentACar.Business.Validation.FluentValidation;
using RentACar.Core.Aspects.Autofac.Caching;
using RentACar.Core.Aspects.Autofac.Performance;
using RentACar.Core.Aspects.Autofac.Validation;
using RentACar.Core.Utilities.FluentValidation;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Concrete
{
    public class CarManager:ICarService
    {
        private static ICarDal cardal;
        private static ICarImagesDal carImagesDal;
        private IFileProcess fileProcess;

        public CarManager(ICarDal _cardal, ICarImagesDal _carImagesDal, IFileProcess fileProcess)
        {
            //Constructor Injection
            cardal = _cardal;
            carImagesDal = _carImagesDal;
            this.fileProcess = fileProcess;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            CheckValidator.Validate(new CarValidator(), car);
            cardal.Add(car);
            if(!CheckCarImageExist(car.Id))
                carImagesDal.Add(new CarImage
                {
                    CarId = car.Id,
                    CreatedDate = DateTime.UtcNow,
                    ImagePath = "thumbnail.png"
                });
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
        /// <summary>
        /// All Car data will be removed when the car delete
        /// </summary>
        /// <param name="id">Car Id</param>
        /// <returns></returns>
        public IResult Delete(int id)
        {
            var DeletedCar = GetById(id).Data;
            cardal.Delete(DeletedCar);
            var DeletedCarImages = carImagesDal.GetAll(pre => pre.CarId == DeletedCar.Id);
            foreach (var deletedCarImage in DeletedCarImages)
            {
                carImagesDal.Delete(deletedCarImage);
                if (!deletedCarImage.ImagePath.Equals("thumbnail.png"))
                {
                    fileProcess.Delete(deletedCarImage.ImagePath);
                }
            }
            return new SuccessResult(Messages.Delete_Message(typeof(Car).Name));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = cardal.Get(id);
            return new SuccessDataResult<Car>(result);
        }

        [SecuredOperation("cars.getall")]
        //[PerformanceAspect(2)]
        //[CacheAspect]
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

        [CacheAspect]
        public IDataResult<List<GetCarImagesDto>> GetAllImagesById(int id)
        {
            var result = cardal.GetCarImageDetails(car => car.Id == id);
            return new SuccessDataResult<List<GetCarImagesDto>>(result);
        }

        #region Business Rules for Car Manager
        public static bool CheckCarImageExist(int id)
        {
            return carImagesDal.IsExist(id);
        }

        #endregion
    }
}
