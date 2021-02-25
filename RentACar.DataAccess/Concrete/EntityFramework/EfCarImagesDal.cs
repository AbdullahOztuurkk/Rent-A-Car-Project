using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Http;
using RentACar.Core.DataAccess;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImage, RentACarContext>, ICarImagesDal
    {
        
    }
}
