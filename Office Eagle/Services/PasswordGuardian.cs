using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Office_Eagle.Services
{
    public class PasswordGuardian
    {
        private const int SaltSize = 16;
        private const int HashSize = 256 / 8;
        private const int IterationCount = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt = GenerateSalt();

            byte[] hashedPassword = HashPassword(password, salt);

            return Convert.ToBase64String(salt) + Convert.ToBase64String(hashedPassword);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashedPasswordBytes, 0, salt, 0, SaltSize);

            byte[] hashedPasswordToVerify = HashPassword(password, salt);

            return AreByteArraysEqual(hashedPasswordBytes, salt.Length, hashedPasswordToVerify);
        }

        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: IterationCount,
                numBytesRequested: HashSize
            );
        }

        private static bool AreByteArraysEqual(byte[] array1, int length, byte[] array2)
        {
            if (array1.Length < length || array2.Length < length)
            {
                return false;
            }

            for (int i = 0; i < length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

}
