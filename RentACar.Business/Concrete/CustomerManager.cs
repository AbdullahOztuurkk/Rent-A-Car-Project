using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            //constructor injection
            this.customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            customerDal.Add(customer);
            return  new SuccessResult(Messages.Add_Message(typeof(Customer).Name));
        }

        public IResult Update(Customer customer)
        {
            customerDal.Update(customer);
            return new SuccessResult( Messages.Update_Message(typeof(Customer).Name));
        }

        public IResult Delete(int id)
        {
            customerDal.Delete(GetById(id).Data);
            return new SuccessResult( Messages.Delete_Message(typeof(Customer).Name));
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = customerDal.Get(id);
            return new SuccessDataResult<Customer>(result);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }
    }
}
