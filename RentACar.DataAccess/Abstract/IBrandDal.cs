using System.Collections.Generic;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    /// <summary>
    /// Brand Data Access class implemented by IEntityRepository
    /// </summary>
    public interface IBrandDal:IEntityRepository<Brand>
    {
        public void AddRange(List<Brand> brands);
    }
}
