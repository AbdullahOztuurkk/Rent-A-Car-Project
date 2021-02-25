using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Abstract
{
    /// <summary>
    /// Car Data Access class implemented by IEntityRepository
    /// </summary>
    public interface ICarDal:IEntityRepository<Car>
    {
        public void AddRange(List<Car> cars);
        public List<GetCarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        public List<GetCarImagesDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null);
    }
}
