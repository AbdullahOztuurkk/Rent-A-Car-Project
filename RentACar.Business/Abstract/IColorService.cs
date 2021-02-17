using System.Collections.Generic;
using RentACar.Core.Utilities.Result;
using RentACar.Entities.Concrete;

namespace RentACar.Business.Abstract
{
    public interface IColorService
    {
        public IResult Add(Color color);
        public IResult Update(Color color);
        public IResult Delete(int id);
        public IDataResult<Color> GetById(int id);
        public IDataResult<List<Color>> GetAll();
        public IDataResult<List<Color>> GetByName(string name);
        public IResult AddRange(List<Color> colors);

    }
}
