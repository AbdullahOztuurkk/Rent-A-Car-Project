using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    /// <summary>
    /// Business Brand class
    /// </summary>
    public class BrandManager:IBrandService
    {
        private IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            //Create instance with constructor injection
            this.brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            brandDal.Add(brand);
            return new SuccessResult(Messages.Add_Message(typeof(Brand).Name));
        }

        public IResult Update(Brand brand)
        {
            brandDal.Update(brand);
            return new SuccessResult(Messages.Update_Message(typeof(Brand).Name));
        }

        public IResult Delete(int id)
        {
            brandDal.Delete(GetById(id).Data);
            return new SuccessResult( Messages.Delete_Message(typeof(Brand).Name));

        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = brandDal.Get(id);
            return new SuccessDataResult<Brand>(result);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<List<Brand>> GetByName(string name)
        {
            var result = brandDal.GetAll(brand => brand.Name.Contains(name));
            return new SuccessDataResult<List<Brand>>(result);

        }

        public IResult AddRange(List<Brand> brands)
        {
            brandDal.AddRange(brands);
            return new SuccessDataResult<List<Brand>>(Messages.Multiple_Add_Message(typeof(Brand).Name));
        }
    }
}
