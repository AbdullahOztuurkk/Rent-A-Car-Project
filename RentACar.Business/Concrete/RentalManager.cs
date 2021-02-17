using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this.rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = rentalDal.GetAll(rent => rent.CarId == rental.CarId);
            if (result.Count > 0)
            {
                foreach (var rental1 in result)
                {
                    if(rental1.ReturnDate ==null)
                        return new ErrorResult(Messages.Car_Must_Be_Rental);
                }
            }
            return new SuccessResult(Messages.Add_Message(typeof(Rental).Name));
        }

        public IResult Update(Rental rental)
        {
            rentalDal.Update(rental);
            return new SuccessResult(Messages.Update_Message(typeof(Rental).Name));
        }

        public IResult Delete(int id)
        {
            rentalDal.Add(GetById(id).Data);
            return new SuccessResult(Messages.Delete_Message(typeof(Rental).Name));
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = rentalDal.Get(id);
            return new SuccessDataResult<Rental>(result);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }
    }
}
