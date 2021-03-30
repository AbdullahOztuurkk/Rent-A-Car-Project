using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
