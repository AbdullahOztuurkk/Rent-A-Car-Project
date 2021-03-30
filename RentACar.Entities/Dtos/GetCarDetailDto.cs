using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos
{
    public class GetCarDetailDto:IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public bool IsRentable { get; set; }
        public string ImagePath { get; set; }
    }
}
