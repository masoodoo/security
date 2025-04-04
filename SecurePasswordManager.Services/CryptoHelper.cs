using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecurePasswordManager.Services
{
    public static class CryptoHelper
    {
        private static byte[] GenerateSalt(int size = 16)
        {
            var salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static (string EncryptedData, byte[] Salt, byte[] IV) Encrypt(string data, string password)
        {
            byte[] salt = GenerateSalt();
            byte[] iv = GenerateSalt(16);
            byte[] key = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(data);
                        cs.Write(plainBytes, 0, plainBytes.Length);
                    }
                    return (Convert.ToBase64String(ms.ToArray()), salt, iv);
                }
            }
        }

        public static string Decrypt(string encryptedData, string password, byte[] salt, byte[] iv)
        {
            try
            {
                byte[] key = new Rfc2898DeriveBytes(password, salt, 10000).GetBytes(32);
                byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Padding = PaddingMode.PKCS7; // مشخص کردن Padding Mode

                    using (var decryptor = aes.CreateDecryptor())
                    using (var ms = new MemoryStream(encryptedBytes))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (CryptographicException ex)
            {
                // لاگ خطا برای دیباگ
                Console.WriteLine($"Decryption failed: {ex.Message}");
                throw new Exception("رمز عبور نامعتبر است یا داده‌ها آسیب دیده‌اند", ex);
            }
        }
    }
}
