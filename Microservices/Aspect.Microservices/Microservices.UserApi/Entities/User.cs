namespace Microservices.UserApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage {  get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public string Country {  get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
