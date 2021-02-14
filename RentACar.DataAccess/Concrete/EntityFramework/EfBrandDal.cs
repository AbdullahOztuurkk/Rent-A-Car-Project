using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal:EfEntityRepositoryBase<Brand,RentACarContext>,IBrandDal
    {
        public void AddRange(List<Brand> brands)
        {
            using (RentACarContext context = new RentACarContext())
            {
                context.AddRange(brands);
            }
        }
    }
}
