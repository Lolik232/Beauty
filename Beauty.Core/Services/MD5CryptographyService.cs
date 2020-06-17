using Beauty.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Beauty.Core.Services
{
    public class MD5CryptographyService : ICryptographyService
    {
        public HashAlgorithm HashAlgorithm { get; private set; }

        public MD5CryptographyService()
        {
            HashAlgorithm = MD5.Create();
        }

        public string GetHash(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = HashAlgorithm.ComputeHash(bytes);

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
