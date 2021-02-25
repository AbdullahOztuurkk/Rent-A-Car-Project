using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    /// <summary>
    /// General Image Interface 
    /// </summary>
    public interface ICarImageService
    {
        public IResult Add(int id, IFormFile file);
        public IResult Delete(int id);
        public IDataResult<CarImage> GetById(int id);
        public IDataResult<List<CarImage>> GetAll();
    }
}
