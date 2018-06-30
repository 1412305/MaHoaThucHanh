using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class FileVerifySignatureModel : BaseModel
    {
        public string FileVerifyName { get; set; }
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");
        public string FileSignatureName { get; set; }
        public XmlService XmlService { get; set; }
        public RSAService RSAService { get; set; }

        public FileVerifySignatureModel()
        {
            XmlService = new XmlService();
            RSAService = new RSAService();
        }

        internal bool VerifySignature()
        {
            if (!Validate())
                return false;

            var users = this.GetAllUsers();
            bool isValid = false;
            var signatureOwner = string.Empty;
            foreach (var user in users)
            {
                var publicKey = Encoding.UTF8.GetString(Convert.FromBase64String(user.PublicKey));
                var isVerified = RSAService.VerifySignature(FileVerifyName, FileSignatureName, publicKey);
                if (isVerified)
                {
                    isValid = true;
                    signatureOwner = user.Email;
                    break;
                }
            }


            if (isValid)
            {
                this.InfoMessage = $"The signature is valid and belongs to {signatureOwner}.";
            }
            else
            {
                this.InfoMessage = $"Failed to verify the signature.";
            }
            return true;
        }

        private List<UserDto> GetAllUsers()
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var fileInfos = directoryInfo.GetFiles("*.xml").ToList();
            var users = new List<UserDto>();
            foreach (var fileInfo in fileInfos)
            {
                users.Add(XmlService.ReadFromXml<UserDto>(fileInfo.FullName));
            }
            return users;
        }

        public bool Validate()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.FileSignatureName))
            {
                message.AppendLine("File signature location field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(this.FileVerifyName))
            {
                message.AppendLine("File verify location field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }
    }
}
