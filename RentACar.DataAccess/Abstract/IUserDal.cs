﻿using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
