using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class UserUpdateModel : BaseModel
    {
        public UserDto User { get; set; }
        public HashService HashService { get; set; }
        public XmlService XmlService { get; set; }

        public UserUpdateModel()
        {
            HashService = new HashService();
            XmlService = new XmlService();
        }
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");

        public bool UpdateUserInfo()
        {
            try
            {
                if (!IsUserValid())
                {
                    return false;
                }

                var emailEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.User.Email));
                var filePath = Path.Combine(DatabaseDir, emailEncoded);
                filePath = Path.ChangeExtension(filePath, "xml");

                User.Passphrase = HashService.SHA256Hash(User.Passphrase, User.Salt);
                XmlService.WriteToXml(filePath, User);
                this.InfoMessage = "Update successfully";

                return true;
            }
            catch (Exception ex)
            {
                this.WarningMessage = "There was an error updating your account";
                return false;
            }

        }

        private bool IsUserValid()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.User.Passphrase))
            {
                message.AppendLine("Passphrase field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }
    }
}
