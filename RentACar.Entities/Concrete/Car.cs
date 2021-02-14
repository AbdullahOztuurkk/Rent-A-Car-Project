using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }

        //Relations
        public Brand  Brand { get; set; }
        public Color Color { get; set; }

    }
}
