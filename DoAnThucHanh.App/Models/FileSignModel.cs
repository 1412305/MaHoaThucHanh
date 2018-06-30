using DoAnThucHanh.App.DTOs;
using DoAnThucHanh.App.Services;
using System;
using System.Text;

namespace DoAnThucHanh.App.Models
{
    public class FileSignModel : BaseModel
    {
        public UserDto User { get; set; }
        public RSAService RSAService { get; set; }
        public SymetricService SymetricService { get; set; }
        public string FileSignName { get; internal set; }

        public FileSignModel()
        {
            User = new UserDto();
            RSAService = new RSAService();
            SymetricService = new SymetricService();
        }

        internal bool SignFile()
        {
            if (!Validate())
                return false;

            try
            {
                var privateKey = GetPrivateKey();
                RSAService.Sign(this.FileSignName, privateKey);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public string GetPrivateKey()
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

            if (string.IsNullOrWhiteSpace(this.FileSignName))
            {
                message.AppendLine("File encrypt location field is missing.");
                result = false;
            }

            this.WarningMessage = message.ToString();
            return result;
        }
    }
}
