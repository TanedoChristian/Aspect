namespace AspectUI.Models
{
    public class UserPayment
    {
        public int UserId { get; set; }
        public IEnumerable<Cart> Cart { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryNumber { get; set; }
        public string CVC { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
