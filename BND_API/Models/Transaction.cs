namespace BND_API.Models
{
    public record CreateTransactionRequest
    {
        public Guid FromAccountID { get; set; }
        public Guid ToAccountID { get; set; }
        public decimal Amount { get; set; }
    }

    public record Transaction : CreateTransactionRequest
    {
        public Guid TransactionID { get; set; } 
        public DateTime AttemptedOn { get; set; }
        public bool WasSuccessful { get; set; }
    }
}