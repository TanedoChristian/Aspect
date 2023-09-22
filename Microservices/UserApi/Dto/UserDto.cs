using UserApi.Entities;

namespace UserApi.Dto
{
    public class UserDto
    {

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AddressDto Address { get; set; }

    }
}
