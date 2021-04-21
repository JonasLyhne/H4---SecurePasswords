using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswordLogic.Hashing
{
    public class HashPassword
    {
        public byte[] HashWithPasswordSalt(string password, byte[]salt, int iterations)
        {
            using var cryptographer = new Rfc2898DeriveBytes(password, salt, iterations);
            return cryptographer.GetBytes(64);
        }
    }
}