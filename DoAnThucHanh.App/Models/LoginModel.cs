using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class LoginModel : BaseModel
    {
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");
        public UserDto User { get; set; }
        public string Email { get; set; }
        public string Passphrase { get; set; }
        private XmlService XmlService { get; set; }
        private HashService HashService { get; set; }

        public LoginModel()
        {
            HashService = new HashService();
            XmlService = new XmlService();
        }

        public bool IsUserValid()
        {
            if (!IsInputValid())
            {
                return false;
            }

            if (this.EmailExists())
            {
                var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Email));
                var filePath = Path.Combine(DatabaseDir, encodedEmail);
                filePath = Path.ChangeExtension(filePath, "xml");
                this.User = XmlService.ReadFromXml<UserDto>(filePath);
                if (this.IsPassphraseMatch())
                {
                    return true;
                }
                else
                {
                    this.WarningMessage = "Invalid passphrase";
                    return false;
                }
            }
            else
            {
                this.WarningMessage = "Invalid email";
                return false;
            }
        }

        private bool IsPassphraseMatch()
        {
            var hashInputPassphrase = HashService.SHA256Hash(this.Passphrase, this.User.Salt);
            return hashInputPassphrase.Equals(this.User.Passphrase);
        }

        private bool EmailExists()
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Email));
            var fileName = Path.ChangeExtension(encodedEmail, "xml");
            return directoryInfo.GetFiles("*.xml")
                    .Select(x => x.Name)
                    .Any(x => x.Equals(fileName));
        }

        private bool IsInputValid()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.Email))
            {
                message.AppendLine("Email field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(this.Passphrase))
            {
                message.AppendLine("Passphrase field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }

        public void ExportKeyPair(string fileName)
        {
            XmlService.WriteToXml(fileName, new ExportingUserDto(this.User));
        }
    }
}
