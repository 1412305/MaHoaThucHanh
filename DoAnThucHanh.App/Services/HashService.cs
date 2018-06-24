using System.Security.Cryptography;
using System.Text;

namespace DoAnThucHanh.App.Services
{
    public class HashService
    {
        public HashService()
        {

        }

        public void SHA256Hash(string pass, string salt)
        {
            var saltedPass = new StringBuilder(pass);
            saltedPass.Append(salt);

            using (var sha = new SHA256Managed())
            {
            }
        }
    }
}
