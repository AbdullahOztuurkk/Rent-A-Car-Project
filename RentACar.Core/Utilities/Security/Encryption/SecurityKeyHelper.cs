using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        /// <summary>
        /// Generate a security key for secure password
        /// </summary>
        /// <param name="securityKey"></param>
        /// <returns></returns>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
