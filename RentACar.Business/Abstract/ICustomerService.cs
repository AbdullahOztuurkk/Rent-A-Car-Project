using System.Collections.Generic;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.Business.Abstract
{
    public interface ICustomerService
    {
        public IResult Add(Customer customer);
        public IResult Update(Customer customer);
        public IResult Delete(int id);
        public IDataResult<Customer> GetById(int id);
        public IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IDataResult<List<CustomerDetailDto>> GetCustomersByCarId(int carId);
    }
}
