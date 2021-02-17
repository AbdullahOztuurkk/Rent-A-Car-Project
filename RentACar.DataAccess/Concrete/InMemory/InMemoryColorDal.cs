using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RentACar.Core.DataAccess;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.DataAccess.Concrete.InMemory
{
    /// <summary>
    /// InMemory Color Data access class with some dummy data
    /// </summary>
    public class InMemoryColorDal:IEntityRepository<Color>,IColorDal
    {
        private List<Color> colorList;

        public InMemoryColorDal()
        {
            colorList=new List<Color>()
            {
                new Color(){ Id = 1 ,Name = "Red"},
                new Color(){ Id = 2 ,Name = "Blue"},
                new Color(){ Id = 3 ,Name = "Purple"},
                new Color(){ Id = 4 ,Name = "Orange"},
                new Color(){ Id = 5 ,Name = "Black"},
                new Color(){ Id = 6 ,Name = "White"},
                new Color(){ Id = 7 ,Name = "Gray"}
            };
        }
        public Color Get(int id)
        {
            return colorList.Where(color => color.Id == id).FirstOrDefault();
        }

        public void Add(Color entity)
        {
            colorList.Add(entity);
        }

        public void Update(Color entity)
        {
            var currentColor = colorList.Where(color => color.Id == entity.Id).FirstOrDefault();
            currentColor.Name = entity.Name;
        }

        public void Delete(Color entity)
        {
            colorList.Remove(colorList.Where(color => color.Id == entity.Id).FirstOrDefault());
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return colorList;
        }

        public void AddRange(List<Color> colors)
        {
            colorList.AddRange(colors);
        }
    }
}
