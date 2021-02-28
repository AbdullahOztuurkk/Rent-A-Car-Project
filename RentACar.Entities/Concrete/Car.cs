using System.Collections.Generic;
using System.Text.Json.Serialization;
using RentACar.Core.Entities;
using RentACar.Entities.Attributes;

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
        [SkipProperty]
        [JsonIgnore]
        public Brand  Brand { get; set; }
        [SkipProperty]
        [JsonIgnore]
        public Color Color { get; set; }
    }
}
