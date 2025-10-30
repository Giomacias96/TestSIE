using System;
using System.Security.Cryptography;
using System.Text;

namespace TestSie
{
    /// <summary>
    /// Clase para encriptar y desencriptar strings
    /// </summary>
    public static class Crypt
    {
        /// <summary>
        /// Encripta el string especificado.
        /// </summary>
        /// <param name="input">El string a encriptar.</param>
        /// <param name="key">La llave con la que se encriptara el string.</param>
        /// <returns>El string encriptado</returns>
        public static string Encrypt(string input, string key)
        {
            try
            {
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Desencripta el string especificado
        /// </summary>
        /// <param name="input">El string a desencriptar.</param>
        /// <param name="key">La llave con la que se encriptó el string.</param>
        /// <returns>El string desencriptado</returns>
        public static string Decrypt(string input, string key)
        {
            try
            {

                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// Desencripta el string especificado the data.
        /// </summary>
        /// <param name="textEncryption">El string a descencriptar.</param>
        /// <param name="key">La llave con la que se encriptó el string</param>
        /// <param name="usehashing">if set to <c>true</c> [usehashing].</param>
        /// <returns>El string desencriptado</returns>
        public static string DecryptionData(string textEncryption, string key, bool usehashing)
        {
            try
            {
                byte[] keyarray;
                byte[] toencrypArray = Convert.FromBase64String(textEncryption);

                if (usehashing)
                {
                    MD5CryptoServiceProvider prsMd5 = new MD5CryptoServiceProvider();
                    keyarray = prsMd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    prsMd5.Clear();
                }
                else
                {
                    keyarray = UTF8Encoding.UTF8.GetBytes(key);
                }
                TripleDESCryptoServiceProvider tpdes = new TripleDESCryptoServiceProvider();
                tpdes.Key = keyarray;
                tpdes.Mode = CipherMode.ECB;
                tpdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cryTransfor = tpdes.CreateDecryptor();
                byte[] resulArray = cryTransfor.TransformFinalBlock(toencrypArray, 0, toencrypArray.Length);
                tpdes.Clear();
                return UTF8Encoding.UTF8.GetString(resulArray);


            }
            catch
            {
                throw;
            }
        }
    }
}