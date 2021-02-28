using System.Collections.Generic;
using System.Linq;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            //constructor injection
            this.userDal = userDal;
        }

        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult( Messages.Add_Message(typeof(User).Name));
        }

        public IResult Update(User user)
        {
            userDal.Update(user);
            return new SuccessResult( Messages.Update_Message(typeof(User).Name));
        }

        public IResult Delete(int id)
        {
            userDal.Delete(GetById(id).Data);
            return new SuccessResult( Messages.Delete_Message(typeof(User).Name));
        }

        public IDataResult<User> GetById(int id)
        {
            var result = userDal.Get(id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
            return userDal.GetAll(pre => pre.Email == email).FirstOrDefault();
        }
    }
}
