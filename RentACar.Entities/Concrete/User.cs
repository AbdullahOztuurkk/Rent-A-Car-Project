using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities;

namespace RentACar.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }

    }
}
