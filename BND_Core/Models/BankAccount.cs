namespace BND_Core.Models
{
    public record CreateBankAccountRequest
    {
        public Guid OwnerCustomerID { get; set; }
        public string IBAN { get; set; }
    }

    public record BankAccount : CreateBankAccountRequest
    {
        public Guid AccountID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}