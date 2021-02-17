using System.Collections.Generic;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    /// <summary>
    /// Color Data Access class implemented by IEntityRepository
    /// </summary>
    public interface IColorDal : IEntityRepository<Color>
    {
        public void AddRange(List<Color> colors);
    }
}