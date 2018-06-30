using DoAnThucHanh.App.Enums;
using System;
using System.Security.Cryptography;

namespace DoAnThucHanh.App.DTOs
{
    [Serializable]
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

        public byte[] Key { get; set; }

        public byte[] IV { get; set; }

    }
}
