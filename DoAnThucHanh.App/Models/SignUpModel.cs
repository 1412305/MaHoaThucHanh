﻿using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Linq;

namespace DoAnThucHanh.App.Models
{
    public class SignUpModel : BaseModel
    {
        public UserDto User { get; set; }
        public int? KeySize { get; set; }
        private XmlService XmlService { get; set; }
        private RSAService RSAService { get; set; }
        private HashService HashService { get; set; }
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");

        public SignUpModel()
        {
            XmlService = new XmlService();
            RSAService = new RSAService();
            HashService = new HashService();

            User = new UserDto();
            User.Salt = Guid.NewGuid().ToString();
        }

        public bool SignUp()
        {
            try
            {
                if (!Directory.Exists(DatabaseDir))
                {
                    Directory.CreateDirectory(DatabaseDir);
                }

                var emailExists = this.CheckUniqueEmail();
                if (emailExists)
                {
                    this.WarningMessage = "This email already exists. Please choose another one!";
                    return false;
                }

                var filePath = Path.Combine(DatabaseDir, this.User.Email);
                filePath = Path.ChangeExtension(filePath, "xml");

                var keyPair = RSAService.GenerateKeyPair((int)this.KeySize);
                User.PrivateKey = keyPair.PrivateKey;
                User.PublicKey = keyPair.PublicKey;
                User.Passphrase = HashService.SHA256Hash(User.Passphrase, User.Salt);

                XmlService.WriteToXml<UserDto>(filePath, User);
                this.InfoMessage = "Sign up successfully";
            }
            catch (Exception ex)
            {
                this.WarningMessage = "There was an error creating your account";
                return false;
            }

            return true;
        }

        public bool CheckUniqueEmail()
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var email = Path.ChangeExtension(this.User.Email, "xml");
            return directoryInfo.GetFiles("*.xml")
                    .Select(x => x.Name)
                    .Any(x => x.Equals(email));
        }
    }
}
