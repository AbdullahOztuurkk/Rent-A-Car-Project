using System.Collections.Generic;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface IBrandService
    {

        public IResult Add(Brand brand);
        public IResult Update(Brand brand);
        public IResult Delete(int id);
        public IDataResult<Brand> GetById(int id);
        public IDataResult<List<Brand>> GetAll();
        public IDataResult<List<Brand>> GetByName(string name);
        public IResult AddRange(List<Brand> brands);
    }
}
