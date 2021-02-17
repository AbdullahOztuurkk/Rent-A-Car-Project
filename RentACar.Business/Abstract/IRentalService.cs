using System.Collections.Generic;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface IRentalService
    {
        public IResult Add(Rental rental);
        public IResult Update(Rental rental);
        public IResult Delete(int id);
        public IDataResult<Rental> GetById(int id);
        public IDataResult<List<Rental>> GetAll();
    }
}
