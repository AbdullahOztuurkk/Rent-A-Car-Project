﻿using System.Collections.Generic;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Abstract
{
    public interface ICarService
    {

        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(int id);
        public IDataResult<Car> GetById(int id);
        public IDataResult<List<Car>> GetAll();
        public IDataResult<List<Car>> GetByModelYear(int ModelYear);
        public IDataResult<List<Car>> GetByDailyPrice(int price);
        public IDataResult<List<Car>> GetByDescription(string description);
        public IDataResult<List<Car>> GetByName(string name);
        public IDataResult<List<Car>> GetByBrandId(int BrandId);
        public IDataResult<List<Car>> GetByColorId(int ColorId);
        public IDataResult<List<GetCarImagesDto>> GetAllImagesById(int id);
        public IResult AddRange(List<Car> cars);


        IDataResult<List<GetCarDetailDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<GetCarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<GetCarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<GetCarDetailDto>> GetCarDetails();
    }
}
