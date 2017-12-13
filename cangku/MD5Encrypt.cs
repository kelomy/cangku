using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace MD5Encrypt
{
    class MD5Manager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Md5Encrypt(string strSource)
        {
            byte[] bytIn = System.Text.Encoding.Default.GetBytes(strSource);
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };

            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.IV = iv;
            mobjCryptoService.Key = key;

            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            return System.Convert.ToBase64String(ms.ToArray());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Md5Decrypt(string strSource)
        {
            byte[] bytIn = System.Convert.FromBase64String(strSource);
            byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };
            byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };

            DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
            mobjCryptoService.IV = iv;
            mobjCryptoService.Key = key;

            ICryptoTransform decrypto = mobjCryptoService.CreateDecryptor();
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            CryptoStream cs = new CryptoStream(ms, decrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs, Encoding.Default);

            return sr.ReadToEnd();
        }
    }
}
