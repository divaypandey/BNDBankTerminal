namespace BND_API.Models
{
    public record Transaction
    {
        public Guid TransactionID { get; set; } 
        public DateTime AttemptedOn { get; set; }
        public Guid FromAccountID { get; set; }
        public Guid ToAccountID { get; set; }
        public decimal Amount { get; set; }
        public bool WasSuccessful { get; set; }
    }
}