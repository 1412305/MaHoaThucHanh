using DoAnThucHanh.App.Enums;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DoAnThucHanh.App.Services
{
    public class AesService
    {
        public AesService()
        {
        }

        public bool AESEncryptFile(string fileInput,
            string fileOutput,
            byte[] email,
            byte[] publicKey,
            PaddingMode paddingMode,
            CipherMode cipherMode)
        {
            var aes = new AesManaged();
            var rsa = new RSACryptoServiceProvider();
            aes.Padding = paddingMode;
            aes.Mode = cipherMode;
            aes.KeySize = 256;

            aes.GenerateKey();
            aes.GenerateIV();

            var encryptedKey = rsa.Encrypt(aes.Key, false);
            var algo = Encoding.UTF8.GetBytes(Algorithm.AES.ToString());
            var padding = Encoding.UTF8.GetBytes(paddingMode.ToString());
            var mode = Encoding.UTF8.GetBytes(cipherMode.ToString());

            try
            {
                using (var outFs = new FileStream(fileOutput, FileMode.Create))
                {
                    var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    outFs.Write(algo, 0, algo.Length);
                    outFs.Write(padding, 0, padding.Length);
                    outFs.Write(mode, 0, mode.Length);
                    outFs.Write(email, 0, email.Length);
                    outFs.Write(encryptedKey, 0, encryptedKey.Length);
                    outFs.Write(aes.IV, 0, aes.IV.Length);

                    using (var outCs = new CryptoStream(outFs, encryptor, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        using (var inFs = new FileStream(fileInput, FileMode.Open))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outCs.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            }
                            while (count > 0);
                            inFs.Close();
                        }
                        outCs.FlushFinalBlock();
                        outCs.Close();
                    }
                    outFs.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AESDecryptFile()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
