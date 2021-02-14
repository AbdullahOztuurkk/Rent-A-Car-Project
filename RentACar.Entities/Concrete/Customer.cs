using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
