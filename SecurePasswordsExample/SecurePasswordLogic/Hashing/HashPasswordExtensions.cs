using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswordLogic.Hashing
{
    public static class HashPasswordExtensions
    {
        private const int SaltSize = 32;
        
        public static byte[] GenerateSalt()
        {
            using var provider = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            provider.GetBytes(salt);
            return salt;
        }

        public static string HashToString(byte[] salt)
        {
            return Convert.ToBase64String(salt);
        }

        public static byte[] GetByteArrayFromString(string input)
        {
            return Convert.FromBase64String(input);
        }
    }
}