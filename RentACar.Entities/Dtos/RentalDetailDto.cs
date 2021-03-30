using System;
using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos
{
    public class RentalDetailDto:IDto
    {
        public int CarId { get; set; }
        public int RentalId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}