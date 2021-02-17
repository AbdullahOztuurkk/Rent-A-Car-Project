using System.Collections.Generic;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    /// <summary>
    /// Car Data Access class implemented by IEntityRepository
    /// </summary>
    public interface ICarDal:IEntityRepository<Car>
    {
        public void AddRange(List<Car> cars);
    }
}
