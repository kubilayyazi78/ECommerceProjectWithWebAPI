﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.MD5
{
    public class MD5Service : IMD5Service
    {
        private string hash = "ASPDOTNETMVC24042022";
        public string ConvertTextToMD5(string text)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            return EncryptionToMD5(text, provider);
        }

        private string EncryptionToMD5(string text, HashAlgorithm algorithm)
        {
            byte[] byteValues = Encoding.UTF8.GetBytes(text);
            byte[] encrBytes = algorithm.ComputeHash(byteValues);
            return Convert.ToBase64String(encrBytes);
        }

        public string Encrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public string Decrypt(string encryptedValue)
        {
            byte[] data = Convert.FromBase64String(encryptedValue);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }

            }
        }
    }
}
