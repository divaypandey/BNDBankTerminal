using BND_API.Models;

namespace BND_API.Services
{
    public interface IBankAccountService
    {
        public Task<BankAccount> GetBankAccountByID(Guid accountID);
        public Task<IEnumerable<BankAccount>> GetCustomerBankAccounts(Guid customerID);
        public Task<BankAccount> CreateBankAccountForCustomer(CreateBankAccountRequest request);
    }

    public class BankAccountService : IBankAccountService
    {
        public Task<BankAccount> CreateBankAccountForCustomer(CreateBankAccountRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<BankAccount> GetBankAccountByID(Guid accountID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BankAccount>> GetCustomerBankAccounts(Guid customerID)
        {
            throw new NotImplementedException();
        }
    }
}
