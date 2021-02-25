using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Entities.Dtos
{
    public class GetCarImagesDto
    {
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
