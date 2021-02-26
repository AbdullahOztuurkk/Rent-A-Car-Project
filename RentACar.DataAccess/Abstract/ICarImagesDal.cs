using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using RentACar.Core.DataAccess;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Abstract
{
    public interface ICarImagesDal:IEntityRepository<CarImage>
    {
        public bool IsExist(int id);
    }
}
