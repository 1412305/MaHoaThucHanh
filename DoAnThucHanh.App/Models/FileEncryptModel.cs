using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Enums;
using DoAnThucHanh.App.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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
        public SymetricService SymetricService { get; set; }
        public XmlService XmlService { get; set; }

        public FileEncryptModel()
        {
            EncryptInfo = new EncryptingFileInfo();
            this.LoadEmails();
            this.LoadAlgorithm();
            this.LoadPaddingModes();
            this.LoadCipherModes();
            SymetricService = new SymetricService();
            XmlService = new XmlService();
        }

        private void LoadCipherModes()
        {
            CipherModes = new List<TextValuePair>
            {
                new TextValuePair(CipherMode.CBC.ToString(), CipherMode.CBC),
                new TextValuePair(CipherMode.CFB.ToString(), CipherMode.CFB),
                new TextValuePair(CipherMode.ECB.ToString(), CipherMode.ECB),
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
            try
            {
                SymetricService.EncryptFile(FileEncryptName,
                        FileSaveName,
                        this.EncryptInfo,
                        publicKey);
            }
            catch (Exception ex)
            {
                this.WarningMessage = "There was an error when encrypting file.";
                return false;
            }

            return true;
        }

        public string GetReceiverPublicKey(string email)
        {
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            var filePath = Path.Combine(DatabaseDir, encodedEmail);
            filePath = Path.ChangeExtension(filePath, "xml");
            var user = XmlService.ReadFromXml<UserDto>(filePath);
            var publicKey = Convert.FromBase64String(user.PublicKey);
            return Encoding.UTF8.GetString(publicKey);
        }

        public bool Validate()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.FileEncryptName))
            {
                message.AppendLine("File encrypt location field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(this.FileSaveName))
            {
                message.AppendLine("File save location field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }
    }
}
