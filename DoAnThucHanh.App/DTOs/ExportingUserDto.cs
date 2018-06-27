namespace DoAnThucHanh.App.DTOs
{
    public class ExportingUserDto
    {
        public ExportingUserDto()
        {

        }

        public ExportingUserDto(UserDto userDto)
        {
            Name = userDto.Name;
            Birth = userDto.Birth;
            Phone = userDto.Phone;
            Address = userDto.Address;
            Hash = userDto.Passphrase;
            Salt = userDto.Salt;
            PublicKey = userDto.PublicKey;
            PrivateKey = userDto.PrivateKey;
        }

        public string Name { get; set; }

        public string Birth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
    }
}
