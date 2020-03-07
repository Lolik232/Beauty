using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class MD5CryptographyService : ICryptographyService
    {
        private readonly HashAlgorithm hashAlgorithm;

        public MD5CryptographyService()
        {
            hashAlgorithm = MD5.Create();
        }

        public string GetHash(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = hashAlgorithm.ComputeHash(bytes);

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                var line = hash[i].ToString("x2");
                stringBuilder.Append(line);
            }

            return stringBuilder.ToString();
        }
    }
}
