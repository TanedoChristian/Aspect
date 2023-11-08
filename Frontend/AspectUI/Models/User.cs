using System.Net;

namespace AspectUI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
      
        public string PostalCode { get; set; }
     
       
   
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
