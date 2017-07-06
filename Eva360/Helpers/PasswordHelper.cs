using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Eva360.Helpers
{
    public static class PasswordHelper
    {
        public static String GetSalt() //Generamos el salt
        {
            const String allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randN = new Random();
            var chars = new char[36];
            for (int i = 0; i < 36; i++) {
                chars[i]= allowedChars[Convert.ToInt32(36 * randN.NextDouble())];
            }

            return new String(chars);
        }
                
        public static String MD5Hash(String password) //Encriptamos el password
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++) {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}