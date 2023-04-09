﻿using System.Security.Cryptography;
using System.Text;

namespace Cgi.Appmar.Utils.Security
{
    public static class Hashing
    {
        public static string Hash(string key)
        {
            var Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                var result = hash.ComputeHash(enc.GetBytes(key));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
