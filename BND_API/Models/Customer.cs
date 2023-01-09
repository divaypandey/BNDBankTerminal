using System.Diagnostics.CodeAnalysis;

namespace BND_API.Models
{
    public record CreateCustomerRequest
    {
        [NotNull]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotNull]
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