using RentACar.Core.Entities;
namespace RentACar.Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
