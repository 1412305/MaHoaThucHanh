using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class FileEncryptModel : BaseModel
    {
        public List<TextValuePair> Emails { get; set; }
        public List<TextValuePair> Algorithms { get; set; }
        public List<TextValuePair> PaddingModes { get; set; }
        public List<TextValuePair> CipherModes { get; set; }
        public EncryptingFileInfo EncryptInfo { get; set; }
        public string FileEncryptName { get; set; }
        public string FileSaveName { get; set; }
        public string Email { get; set; }
        private static readonly string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");
        public AesService AesService { get; set; }
        public XmlService XmlService { get; set; }

        public FileEncryptModel()
        {
            EncryptInfo = new EncryptingFileInfo();
            this.LoadEmails();
            this.LoadAlgorithm();
            this.LoadPaddingModes();
            this.LoadCipherModes();
            AesService = new AesService();
            XmlService = new XmlService();
        }

        private void LoadCipherModes()
        {
            CipherModes = new List<TextValuePair>
            {
                new TextValuePair(CipherMode.CBC.ToString(), CipherMode.CBC),
                new TextValuePair(CipherMode.CFB.ToString(), CipherMode.CFB),
                new TextValuePair(CipherMode.CTS.ToString(), CipherMode.CTS),
                new TextValuePair(CipherMode.ECB.ToString(), CipherMode.ECB),
                new TextValuePair(CipherMode.OFB.ToString(), CipherMode.OFB)
            };
        }

        private void LoadAlgorithm()
        {
            Algorithms = new List<TextValuePair>
            {
                new TextValuePair(Algorithm.AES.ToString(), Algorithm.AES),
                new TextValuePair(Algorithm.DES.ToString(), Algorithm.DES),
                new TextValuePair(Algorithm.RC2.ToString(), Algorithm.RC2),
                new TextValuePair(Algorithm.Rijndael.ToString(), Algorithm.Rijndael),
                new TextValuePair(Algorithm.TripleDES.ToString(), Algorithm.TripleDES)
            };
        }

        private void LoadPaddingModes()
        {
            PaddingModes = new List<TextValuePair>
            {
                new TextValuePair(PaddingMode.ANSIX923.ToString(), PaddingMode.ANSIX923),
                new TextValuePair(PaddingMode.ISO10126.ToString(), PaddingMode.ISO10126),
                new TextValuePair(PaddingMode.None.ToString(), PaddingMode.None),
                new TextValuePair(PaddingMode.PKCS7.ToString(), PaddingMode.PKCS7),
                new TextValuePair(PaddingMode.Zeros.ToString(), PaddingMode.Zeros)
            };
        }

        private void LoadEmails()
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var emails = directoryInfo.GetFiles("*.xml")
                .Select(x => Encoding.UTF8.GetString(Convert.FromBase64String(x.Name.Replace(".xml", "")))).ToList();
            Emails = new List<TextValuePair>();

            foreach (var email in emails)
            {
                Emails.Add(new TextValuePair(email, email));
            }
        }

        public bool EncryptFile()
        {
            if (!Validate())
                return false;

            var extension = Path.GetExtension(this.FileEncryptName);
            FileSaveName = Path.ChangeExtension(this.FileSaveName, extension);
            var publicKey = this.GetReceiverPublicKey(this.Email);
            var emailByteArr = Encoding.UTF8.GetBytes(this.Email);

            switch (this.EncryptInfo.Algorithm)
            {
                case Algorithm.AES:
                    AesService.AESEncryptFile(FileEncryptName,
                        FileSaveName,
                        emailByteArr,
                        publicKey,
                        (PaddingMode)this.EncryptInfo.PaddingMode,
                        (CipherMode)this.EncryptInfo.CipherMode
                        );
                    break;
                case Algorithm.DES:
                    break;
                case Algorithm.TripleDES:
                    break;
                case Algorithm.RC2:
                    break;
                case Algorithm.Rijndael:
                    break;
            }
        }

        public byte[] GetReceiverPublicKey(string email)
        {
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            var filePath = Path.Combine(DatabaseDir, encodedEmail);
            filePath = Path.ChangeExtension(filePath, "xml");
            var user = XmlService.ReadFromXml<UserDto>(filePath);
            var publicKey = Convert.FromBase64String(user.PublicKey);
            return publicKey;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
