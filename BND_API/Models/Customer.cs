namespace BND_API.Models
{
    public record CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string PrimaryAddress { get; set; }
        public string CitizenID { get; set; }
    }


    public record Customer : CreateCustomerRequest
    {
        public Guid CustomerID { get; set; }
    }
}