using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class JsonEncrypt : MonoBehaviour
{
    public static (string encryptedText, string iv) Encrypt(string text, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32, '\0').Substring(0, 32));
        byte[] textBytes = Encoding.UTF8.GetBytes(text);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateIV();

            string ivBase64 = Convert.ToBase64String(aes.IV);

            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                byte[] encryptedByte = encryptor.TransformFinalBlock(textBytes,0,textBytes.Length);
                string encryptedText = Convert.ToBase64String(encryptedByte);
                return (encryptedText, ivBase64);
            }
        }
    }

    public static string Decrypt(string encryptedText, string key, string iv)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key.PadRight(32, '\0').Substring(0, 32));
        byte[] ivBytes = Convert.FromBase64String(iv);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.IV = ivBytes;

            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
    
}
