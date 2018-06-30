using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Enums;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace DoAnThucHanh.App.Services
{
    public class SymetricService : IDisposable
    {
        bool disposed = false;
        private readonly RijndaelManaged rijndael;

        public SymetricService()
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

        public byte[] RijndaelGenerateKey()
        {
            rijndael.GenerateKey();
            return rijndael.Key;
        }

        public byte[] RijndaelGenerateIV()
        {
            rijndael.GenerateIV();
            return rijndael.IV;
        }

        public string RijndaelEncryptData(string plainText, byte[] key, byte[] iv)
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

        public string RijndaelDecryptData(byte[] cipherText, byte[] key, byte[] iv)
        {
            var plainText = string.Empty;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plainText;
        }

        public void EncryptFile(string fileInput,
          string fileOutput,
          EncryptingFileInfo fileInfo,
          string publicKey
         )
        {
            SymmetricAlgorithm symmetricAlgorithm = null;
            switch (fileInfo.Algorithm)
            {
                case Algorithm.AES:
                    symmetricAlgorithm = new AesCryptoServiceProvider();
                    symmetricAlgorithm.KeySize = 256;
                    symmetricAlgorithm.BlockSize = 128;
                    break;
                case Algorithm.DES:
                    symmetricAlgorithm = new DESCryptoServiceProvider();
                    symmetricAlgorithm.KeySize = 64;
                    break;
                case Algorithm.TripleDES:
                    symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                    symmetricAlgorithm.KeySize = 192;
                    break;
                case Algorithm.Rijndael:
                    symmetricAlgorithm = new RijndaelManaged();
                    symmetricAlgorithm.KeySize = 256;
                    symmetricAlgorithm.BlockSize = 256;
                    break;
                case Algorithm.RC2:
                    symmetricAlgorithm = new RC2CryptoServiceProvider();
                    symmetricAlgorithm.KeySize = 128;
                    break;
            }
            var rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(publicKey);
            symmetricAlgorithm.Padding = (PaddingMode)fileInfo.PaddingMode;
            symmetricAlgorithm.Mode = (CipherMode)fileInfo.CipherMode;
            symmetricAlgorithm.GenerateKey();
            symmetricAlgorithm.GenerateIV();

            var encryptedKey = rsa.Encrypt(symmetricAlgorithm.Key, false);
            fileInfo.Key = encryptedKey;
            fileInfo.IV = symmetricAlgorithm.IV;

            //var ivLength = new byte[4];
            var fileInfoLen = new byte[4];
            byte[] fileInfoBytes;
            using (var memoryStream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(memoryStream, fileInfo);
                fileInfoBytes = memoryStream.ToArray();
            }

            fileInfoLen = BitConverter.GetBytes(fileInfoBytes.Length);

            try
            {
                using (var outFs = new FileStream(fileOutput, FileMode.Create))
                {
                    var encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
                    outFs.Write(fileInfoLen, 0, 4);
                    outFs.Write(fileInfoBytes, 0, fileInfoBytes.Length);

                    using (var outCs = new CryptoStream(outFs, encryptor, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = symmetricAlgorithm.BlockSize / 8;
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

                //if (fileInfo.IsCompressed)
                //{
                //    var zipDirPath = Path.ChangeExtension(fileOutput, null);
                //    var zipFilePath = Path.ChangeExtension(zipDirPath, "zip");
                //    var encryptedFilePath = Path.Combine(zipDirPath, Path.GetFileName(fileOutput));

                //    Directory.CreateDirectory(zipDirPath);
                //    File.Move(fileOutput, encryptedFilePath);
                //    ZipFile.CreateFromDirectory(zipDirPath, zipFilePath);
                //    Directory.Delete(zipDirPath, true);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DecryptFile(string fileInput, string fileOutput, string privateKey)
        {
            try
            {
                using (var inFs = new FileStream(fileInput, FileMode.Open))
                {
                    var fileInfoLen = new byte[4];
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Seek(0, SeekOrigin.Begin);
                    inFs.Read(fileInfoLen, 0, 3);

                    var infoLen = BitConverter.ToInt32(fileInfoLen, 0);
                    var fileInfoBytes = new byte[infoLen];
                    inFs.Seek(4, SeekOrigin.Begin);
                    inFs.Read(fileInfoBytes, 0, infoLen);
                    var fileEncryptInfo = new EncryptingFileInfo(); ;
                    using (var memoryStream = new MemoryStream(fileInfoBytes, 0, infoLen))
                    {
                        memoryStream.Write(fileInfoBytes, 0, infoLen);
                        memoryStream.Position = 0;
                        fileEncryptInfo = new BinaryFormatter().Deserialize(memoryStream) as EncryptingFileInfo;
                    }

                    var startC = infoLen + 4;
                    var lenC = (int)inFs.Length - startC;
                    var rsa = new RSACryptoServiceProvider();
                    rsa.FromXmlString(privateKey);
                    SymmetricAlgorithm symmetricAlgorithm = null;
                    switch (fileEncryptInfo.Algorithm)
                    {
                        case Algorithm.AES:
                            symmetricAlgorithm = new AesManaged();
                            break;
                        case Algorithm.DES:
                            symmetricAlgorithm = new DESCryptoServiceProvider();
                            break;
                        case Algorithm.TripleDES:
                            symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                            break;
                        case Algorithm.Rijndael:
                            symmetricAlgorithm = new RijndaelManaged();
                            break;
                        case Algorithm.RC2:
                            symmetricAlgorithm = new RC2CryptoServiceProvider();
                            break;
                    }
                    symmetricAlgorithm.KeySize = 256;
                    symmetricAlgorithm.Padding = (PaddingMode)fileEncryptInfo.PaddingMode;
                    symmetricAlgorithm.Mode = (CipherMode)fileEncryptInfo.CipherMode;
                    var keyDecrypted = rsa.Decrypt(fileEncryptInfo.Key, false);
                    var decryptor = symmetricAlgorithm.CreateDecryptor(keyDecrypted, fileEncryptInfo.IV);

                    using (var outFs = new FileStream(fileOutput, FileMode.Create))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = symmetricAlgorithm.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];

                        inFs.Seek(startC, SeekOrigin.Begin);
                        using (var outStreamDecrypted = new CryptoStream(outFs, decryptor, CryptoStreamMode.Write))
                        {
                            do
                            {
                                count = inFs.Read(data, 0, blockSizeBytes);
                                offset += count;
                                outStreamDecrypted.Write(data, 0, count);

                            }
                            while (count > 0);

                            outStreamDecrypted.FlushFinalBlock();
                            outStreamDecrypted.Close();
                        }
                        outFs.Close();
                    }

                    inFs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
