using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Utilities.Security.JWT
{
    /// <summary>
    /// A Token POCO class
    /// </summary>
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
