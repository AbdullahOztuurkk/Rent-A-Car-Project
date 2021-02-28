using System;

namespace RentACar.Core.Utilities.Security.JWT
{
    /// <summary>
    /// A Timed token class
    /// </summary>
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}