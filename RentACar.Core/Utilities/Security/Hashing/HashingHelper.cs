using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        /// <summary>
        /// Generate password hash for better password protection
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="PasswordSalt">Password Salt</param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        /// <summary>
        /// Verify passwords between given password with calculated password
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="passwordHash">Password Hash</param>
        /// <param name="PasswordSalt">Password Salt</param>
        /// <returns>If result is true, password verified.</returns>
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
