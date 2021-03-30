using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
    }
}
