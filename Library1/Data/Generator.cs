using System;
using System.Linq;
using System.Security.Cryptography;


namespace Library1.Data
{
    public class Generator
    {
        private const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const string number = "1234567890";
        private static string gen = "";
        public static string GetRandomString(int length,string type)
        {
            string s = "";
            if(type == "number")
            {
                 gen = number;
            }else
            {
                gen = valid;
            }
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {

                while (s.Length != length)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);
                    char character = (char)oneByte[0];
                    if (gen.Contains(character))
                    {
                        s += character;
                    }
                }
            }
            return s;
        }
    }
}
