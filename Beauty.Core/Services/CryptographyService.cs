using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class CryptographyService : ICryptographyService
    {
        private readonly HashAlgorithm algorithm;

        public CryptographyService()
        {
            algorithm = MD5.Create();
        }

        public string ToMD5Hash(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = algorithm.ComputeHash(bytes);

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
