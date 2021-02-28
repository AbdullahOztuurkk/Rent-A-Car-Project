using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos
{
    /// <summary>
    /// A POCO class for sign up
    /// </summary>
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
