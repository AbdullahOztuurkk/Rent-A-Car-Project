using System.Collections.Generic;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Aspects.Autofac.Caching;
using RentACar.Core.Utilities.Business;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

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
            return  new SuccessResult(Messages.Add_Message(Messages.GetNameDict[typeof(Customer)]));
        }

        public IResult Update(Customer customer)
        {
            var currentCustomer = BusinessRules.Run(CheckIfCustomerExists(customer.Id));
            if (currentCustomer == null)
                return new ErrorResult(Messages.Customer_Must_Be_Exists);
            customerDal.Update(customer);
            return new SuccessResult( Messages.Update_Message(Messages.GetNameDict[typeof(Customer)]));
        }

        public IResult Delete(int id)
        {
            var currentCustomer = BusinessRules.Run(CheckIfCustomerExists(id));
            if(currentCustomer == null)
                return new ErrorResult(Messages.Customer_Must_Be_Exists);
            customerDal.Delete(GetById(id).Data);
            return new SuccessResult( Messages.Delete_Message(Messages.GetNameDict[typeof(Customer)]));
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            var result = customerDal.Get(id);
            return new SuccessDataResult<Customer>(result);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            var result = customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(customerDal.GetCustomerList());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersByCarId(int carId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(customerDal.GetCustomerList(x => x.CarId == carId));
        }

        //Used for update and delete validations with BusinessRules class
        public IResult CheckIfCustomerExists(int id)
        {
            var result = customerDal.Get(id);
            if(result!=null)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
