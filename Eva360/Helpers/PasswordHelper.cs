using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eva360.Helpers
{
    public static class PasswordHelper
    {
        public static String GetRandomSalt()
        {
            const String allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randN = new Random();
            var chars = new char[36];
            for (int i = 0; i < 36; i++){
                chars[i]= allowedChars[Convert.ToInt32(36 * randN.NextDouble())];
            }

            return new String(chars);
        }
    }
}