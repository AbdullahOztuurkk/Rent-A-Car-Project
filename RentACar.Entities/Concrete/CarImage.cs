using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
