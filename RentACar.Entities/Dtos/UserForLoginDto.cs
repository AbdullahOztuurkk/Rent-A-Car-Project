using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Core.Entities;

namespace RentACar.Entities.Dtos
{
    /// <summary>
    /// A POCO class for sign in 
    /// </summary>
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
