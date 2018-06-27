using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class MainFormModel : BaseModel
    {
        public XmlService XmlService { get; set; }
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");

        public MainFormModel()
        {
            XmlService = new XmlService();
        }

        public bool ImportKeyPair(string fileName)
        {
            var userDto = XmlService.ReadFromXml<UserDto>(fileName);

            if (!IsUserValid(userDto))
            {
                return false;
            }

            var emailExists = this.CheckUniqueEmail(userDto.Email);
            if (emailExists)
            {
                this.WarningMessage = "Email already exists.";
                return false;
            }

            var isEmailValid = this.isEmailValid(userDto.Email);
            if (!isEmailValid)
            {
                this.WarningMessage = "Invalid email";
                return false;
            }

            var emailEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(userDto.Email));
            var filePath = Path.Combine(DatabaseDir, emailEncoded);
            filePath = Path.ChangeExtension(filePath, "xml");
            XmlService.WriteToXml(filePath, userDto);

            return true;
        }

        bool isEmailValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckUniqueEmail(string email)
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(email));
            var fileName = Path.ChangeExtension(encodedEmail, "xml");
            return directoryInfo.GetFiles("*.xml")
                    .Select(x => x.Name)
                    .Any(x => x.Equals(fileName));
        }

        private bool IsUserValid(UserDto user)
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message.AppendLine("Email field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(user.Passphrase))
            {
                message.AppendLine("Passphrase field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(user.Salt))
            {
                message.AppendLine("Salt field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(user.PublicKey))
            {
                message.AppendLine("PublicKey field is missing.");
                result = false;
            }
            if (string.IsNullOrWhiteSpace(user.PrivateKey))
            {
                message.AppendLine("Private field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }
    }
}
