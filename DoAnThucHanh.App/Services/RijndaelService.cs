using System;
using System.IO;
using System.Security.Cryptography;

namespace DoAnThucHanh.App.Services
{
    public class RijndaelService : IDisposable
    {
        bool disposed = false;
        private readonly RijndaelManaged rijndael;

        public RijndaelService()
        {
            rijndael = new RijndaelManaged();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                rijndael.Dispose();
            }

            disposed = true;
        }

        public byte[] GenerateKey()
        {
            rijndael.GenerateKey();
            return rijndael.Key;
        }

        public byte[] GenerateIV()
        {
            rijndael.GenerateIV();
            return rijndael.IV;
        }

        public string EncryptData(string plainText, byte[] key, byte[] iv)
        {
            byte[] result;
            var encryptor = rijndael.CreateEncryptor(key, iv);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                    result = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(result);
        }

    }
}
