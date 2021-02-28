using RentACar.Core.DataAccess;
using RentACar.Core.Entities.Concrete;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
