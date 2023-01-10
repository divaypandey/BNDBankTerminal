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

    public record DepositMoneyRequest
    {
        private readonly static decimal ChargeFees = 0.1M;

        public Guid AccountID { get; set; }
        public decimal DepositAmount { get; set; }

        public decimal ActualDepositAmount 
        { 
            get 
            {
                return Math.Max(0, DepositAmount * ChargeFees); 
            } 
        }
    }
}