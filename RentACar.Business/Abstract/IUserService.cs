using System.Collections.Generic;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface IUserService
    {
        public IResult Add(User user);
        public IResult Update(User user);
        public IResult Delete(int id);
        public IDataResult<User> GetById(int id);
        public IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
