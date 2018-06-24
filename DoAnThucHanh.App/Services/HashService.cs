using System.Security.Cryptography;
using System.Text;

namespace DoAnThucHanh.App.Services
{
    public class HashService
    {
        public HashService()
        {

        }

        public string SHA256Hash(string pass, string salt)
        {
            var saltedPass = new StringBuilder(pass);
            saltedPass.Append(salt);

            using (var sha = new SHA256Managed())
            {
                var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(saltedPass.ToString()));
                var hashString = new StringBuilder();

                foreach (var hashByte in hashBytes)
                {
                    hashString.Append(hashByte.ToString("x2"));
                }

                return hashString.ToString();
            }
        }
    }
}
