namespace DoAnThucHanh.App.DTOs
{
    public class UserDto
    {
        public UserDto()
        {
            Name = "";
            Birth = "";
            Phone = "";
            Address = "";
        }

        public string Name { get; set; }

        public string Birth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Passphrase { get; set; }

        public string Salt { get; set; }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
    }
}
