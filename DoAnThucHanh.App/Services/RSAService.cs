using DoAnThucHanh.App.DTOs;
using System.Security.Cryptography;

namespace DoAnThucHanh.App.Services
{
    public class RSAService
    {
        public RSAService()
        {

        }

        public RSAKeyPair GenerateKeyPair(int size)
        {
            var rsaKeyPair = new RSAKeyPair();
            using (var RSA = new RSACryptoServiceProvider(size))
            {
                rsaKeyPair.PublicKey = RSA.ToXmlString(false);
                rsaKeyPair.PrivateKey = RSA.ToXmlString(true);
            }

            return rsaKeyPair;
        }
    }
}
