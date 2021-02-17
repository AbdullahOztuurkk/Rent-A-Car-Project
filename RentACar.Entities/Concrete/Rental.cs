using System;
using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; } 
         
        //Relations
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
