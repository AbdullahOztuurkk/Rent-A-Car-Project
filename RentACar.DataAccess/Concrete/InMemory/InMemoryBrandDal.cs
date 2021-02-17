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
    /// InMemory Brand Data access class with some dummy data
    /// </summary>
    public class InMemoryBrandDal:IEntityRepository<Brand>,IBrandDal
    {
        private List<Brand> brandList;
        public InMemoryBrandDal()
        {
            brandList = new List<Brand>()
            {
                new Brand(){ Id = 1, Name = "Porsche "},
                new Brand(){ Id = 2, Name = "Lamborghini "},
                new Brand(){ Id = 3, Name = "Mercedes "},
            };
        }
        public Brand Get(int id)
        {
            return brandList.Where(brand => brand.Id == id).FirstOrDefault();
        }

        public void Add(Brand entity)
        {
            brandList.Add(entity);
        }

        public void Update(Brand entity)
        {
            var currentBrand = brandList.Where(brand => brand.Id == entity.Id).FirstOrDefault();
            currentBrand.Name = entity.Name;
        }

        public void Delete(Brand entity)
        {
            brandList.Remove(brandList.Where(brand => brand.Id == entity.Id).FirstOrDefault());
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return brandList;
        }

        public void AddRange(List<Brand> brands)
        {
            brandList.AddRange(brands);
        }
    }
}
