namespace Office_Eagle.Services
{
    public class PasswordGuardian
    {
        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return passwordMatches;
        }
    }
}
