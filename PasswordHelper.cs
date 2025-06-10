using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    public static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("X2")); // X2 = uppercase hex
            return builder.ToString();
        }
    }
}
