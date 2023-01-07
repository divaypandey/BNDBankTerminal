using BND_API.Models;

namespace BND_API.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(CreateTransactionRequest request);
        Task<IEnumerable<Transaction>> GetAllTransactionsForAccountID(Guid accountID);
        Task<IEnumerable<Transaction>> GetAllTransactionsForCustomerID(Guid customerID);

    }
    public class TransactionService : ITransactionService
    {
        public Task<Transaction> CreateTransaction(CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactionsForAccountID(Guid accountID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactionsForCustomerID(Guid customerID)
        {
            throw new NotImplementedException();
        }
    }
}
