using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.IO;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class FileDecryptModel : BaseModel
    {
        public string FileDecryptName { get; set; }
        public string FileSaveName { get; set; }
        public UserDto User { get; set; }
        private static readonly string DatabaseDir = Path.Combine(Environment.CurrentDirectory, "Database");
        public SymetricService SymetricService { get; set; }
        public XmlService XmlService { get; set; }

        public FileDecryptModel()
        {
            SymetricService = new SymetricService();
            XmlService = new XmlService();
        }

        public bool DecryptFile()
        {
            if (!Validate())
                return false;

            var extension = Path.GetExtension(this.FileDecryptName);
            FileSaveName = Path.ChangeExtension(this.FileSaveName, extension);
            var privateKey = this.GetReceiverPrivateKey(this.User.Email);
            try
            {
                SymetricService.DecryptFile(FileDecryptName, FileSaveName, privateKey);
            }
            catch (Exception ex)
            {
                this.WarningMessage = $"Cannot decrypted symetric key.{Environment.NewLine}Reason: Wrong user's private key";
                return false;
            }
            return true;
        }

        public string GetReceiverPrivateKey(string email)
        {
            var privateKey = SymetricService.RijndaelDecryptData(Convert.FromBase64String(this.User.PrivateKey),
                Convert.FromBase64String(User.Passphrase),
                         Convert.FromBase64String(User.IV));
            return privateKey;
        }

        public bool Validate()
        {
            var result = true;
            var message = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.FileDecryptName))
            {
                message.AppendLine("File decrypt location field is missing.");
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
