using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface  ICarService
    {

        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(int id);
        public IDataResult<Car> GetById(int id);
        public IDataResult<List<Car>> GetAll();
        public IDataResult<List<Car>> GetByModelYear(int ModelYear);
        public IDataResult<List<Car>> GetByDailyPrice(int price);
        public IDataResult<List<Car>> GetByDescription(string description);
        public IResult AddRange(List<Car> cars);
    }
}
