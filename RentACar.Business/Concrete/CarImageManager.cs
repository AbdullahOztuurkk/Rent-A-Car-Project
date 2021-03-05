using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Aspects.Autofac.Caching;
using RentACar.Core.Utilities.Business;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private static ICarImagesDal carImagesDal;
        private static ICarDal cardal;
        private IFileProcess fileProcess;

        public CarImageManager(ICarImagesDal _carImagesDal, ICarDal _cardal, IFileProcess fileProcess)
        {
            carImagesDal = _carImagesDal;
            cardal = _cardal;
            this.fileProcess = fileProcess;
        }

        public IResult Add(int id,IFormFile files)
        {
            IResult result = BusinessRules.Run(CheckImagesLimit(id),CheckTheCarExists(id));
            if (result!= null)
            {
                return new ErrorResult();
            }

            string FileName = Guid.NewGuid().ToString();
            CarImage carImg=new CarImage
            {
                CarId = id,
                CreatedDate = DateTime.UtcNow,
                ImagePath = FileName
            };
            carImagesDal.Add(carImg);
            var fileResult = fileProcess.Upload(FileName, files);
            return new SuccessResult(Messages.Add_Message(typeof(CarImage).Name));
        }

        public IResult Delete(int id)
        {
            IResult result = BusinessRules.Run(CheckTheCarImageExists(FileId:id), CheckTheCarExists(id));
            if (result != null)
                return null;
            CarImage currentCar = GetById(id).Data;
            carImagesDal.Delete(currentCar);
            if(!currentCar.ImagePath.Equals("thumbnail.png")) // Delete it if current car's image is not thumbnail.
                fileProcess.Delete(currentCar.ImagePath);
            return new SuccessResult(Messages.Add_Message(typeof(CarImage).Name));
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            var result = carImagesDal.Get(id);
            return new SuccessDataResult<CarImage>(result);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = carImagesDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result);
        }

        #region Business rules for car Image class

        public static IResult CheckImagesLimit(int id)
        {
            return carImagesDal.GetAll(img=>img.CarId==id).Count() < 5 ? new Result(true) : new ErrorResult(Messages.Car_Must_Be_Lower_Than_5_Photos);
        }
        public static IResult CheckTheCarExists(int id)
        {
            return cardal.Get(id) != null ? (IResult) new Result(true) : new ErrorResult(Messages.Car_Must_Be_Exists);
        }
        public static IResult CheckTheCarImageExists(int FileId)
        {
            return carImagesDal.Get(FileId) != null ? new Result(true) : new ErrorResult(Messages.Car_Image_Must_Be_Exists);
        }
        #endregion
    }
}
