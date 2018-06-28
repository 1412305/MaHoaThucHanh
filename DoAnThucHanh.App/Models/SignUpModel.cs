using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class SignUpModel : BaseModel
    {
        public UserDto User { get; set; }
        public int? KeySize { get; set; }
        private XmlService XmlService { get; set; }
        private RSAService RSAService { get; set; }
        private HashService HashService { get; set; }
        private RijndaelService RijndaelService { get; set; }
        private static string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");

        public SignUpModel()
        {
            XmlService = new XmlService();
            RSAService = new RSAService();
            HashService = new HashService();
            RijndaelService = new RijndaelService();

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

                if (!IsUserValid())
                {
                    return false;
                }

                var emailExists = this.CheckUniqueEmail();
                if (emailExists)
                {
                    this.WarningMessage = "This email already exists. Please choose another one!";
                    return false;
                }

                var isEmailValid = this.isEmailValid();
                if (!isEmailValid)
                {
                    this.WarningMessage = "Please input a valid email!";
                    return false;
                }

                var emailEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.User.Email));
                var filePath = Path.Combine(DatabaseDir, emailEncoded);
                filePath = Path.ChangeExtension(filePath, "xml");

                var keyPair = RSAService.GenerateKeyPair((int)this.KeySize);
                User.Passphrase = HashService.SHA256Hash(User.Passphrase, User.Salt);
                User.PrivateKey = RijndaelService.RijndaelEncryptData(keyPair.PrivateKey,
                        Convert.FromBase64String(User.Passphrase),
                        RijndaelService.RijndaelGenerateIV());
                User.PublicKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(keyPair.PublicKey));

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

        bool isEmailValid()
        {
            try
            {
                var addr = new MailAddress(this.User.Email);
                return addr.Address == this.User.Email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckUniqueEmail()
        {
            var directoryInfo = new DirectoryInfo(DatabaseDir);
            var encodedEmail = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.User.Email));
            var fileName = Path.ChangeExtension(encodedEmail, "xml");
            return directoryInfo.GetFiles("*.xml")
                    .Select(x => x.Name)
                    .Any(x => x.Equals(fileName));
        }

        private bool IsUserValid()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.User.Email))
            {
                message.AppendLine("Email field is missing.");
                result = false;
            }
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
