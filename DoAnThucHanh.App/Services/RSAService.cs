using DoAnThucHanh.App.DTOs;
using System;
using System.IO;
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

        internal void Sign(string fileSignName, string privateKey)
        {
            try
            {
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    var fileBytes = File.ReadAllBytes(fileSignName);
                    var signature = rsa.SignData(fileBytes, CryptoConfig.MapNameToOID("SHA256"));
                    File.WriteAllBytes(fileSignName + ".sig", signature);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool VerifySignature(string fileVerifyName, string fileSignatureName, string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
                var fileBytes = File.ReadAllBytes(fileVerifyName);
                var signature = File.ReadAllBytes(fileSignatureName);
                return rsa.VerifyData(fileBytes,
                    CryptoConfig.MapNameToOID("SHA256"),
                    signature);
            }
        }
    }
}
