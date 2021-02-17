using System.Collections.Generic;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,RentACarContext>,IColorDal
    {
        public void AddRange(List<Color> colors)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.AddRange(colors);
            }
        }
    }
}
