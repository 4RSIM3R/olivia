using System;
using System.Security.Cryptography;

namespace Olivia.Utils;

public class CustomHash
{
    public static byte[] GenerateSalt()
    {
        // Generate a random salt using the RNGCryptoServiceProvider
        byte[] salt = new byte[16];
        RandomNumberGenerator.Create().GetBytes(salt);
        return salt;
    }

    public static byte[] HashPassword(string password, byte[] salt, int iterations = 100000)
    {
        // Hash the password using PBKDF2 with the same settings as Laravel
        int hashLength = 32;
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(hashLength);
    }

    public static bool Compare(string password, string hashedPassword)
    {

        // Extract the salt and hash from the hashed password
        string[] hashedParts = hashedPassword.Split('$');
        int iterations = int.Parse(hashedParts[2]);
        byte[] salt = Convert.FromBase64String(hashedParts[3]);
        byte[] hash = Convert.FromBase64String(hashedParts[4]);

        byte[] newHash = HashPassword(password, salt, iterations);

        return CompareByteArrays(hash, newHash);
    }

    private static bool CompareByteArrays(byte[] a, byte[] b)
    {
        // Compare two byte arrays for equality
        if (a == null || b == null || a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

}
