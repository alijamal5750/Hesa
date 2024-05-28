using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Sales_Management
{
    class Hash_Password
    {

        public static string hashPassword(string Password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] passwordByte = Encoding.ASCII.GetBytes(Password);
            byte[] encryptByte = sha1.ComputeHash(passwordByte);

            return Convert.ToBase64String(encryptByte);

        }
    }
}
