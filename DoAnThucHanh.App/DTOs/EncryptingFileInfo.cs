using DoAnThucHanh.App.Enums;
using System.Security.Cryptography;

namespace DoAnThucHanh.App.DTOs
{
    public class EncryptingFileInfo
    {
        public EncryptingFileInfo()
        {

        }

        public string Email { get; set; }

        public Algorithm? Algorithm { get; set; }

        public PaddingMode? PaddingMode { get; set; }

        public CipherMode? CipherMode { get; set; }

        public bool IsCompressed { get; set; }
    }
}
