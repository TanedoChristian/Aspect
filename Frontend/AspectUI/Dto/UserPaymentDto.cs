namespace AspectUI.Dto
{
    public class UserPaymentDto
    {
        public int UserId {  get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryNumber { get; set; }
        public string CVC { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
