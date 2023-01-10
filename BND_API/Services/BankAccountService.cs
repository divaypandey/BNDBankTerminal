using BND_API.Data.StoredProcedures;
using BND_Core.Models;
using System.Data;

namespace BND_API.Services
{
    public interface IBankAccountService
    {
        public Task<BankAccount> GetBankAccountByID(Guid accountID);
        public Task<IEnumerable<BankAccount>> GetCustomerBankAccounts(Guid customerID);
        public Task<BankAccount> CreateBankAccountForCustomer(CreateBankAccountRequest request);
        public BankAccount DepositMoneyToAccount(DepositMoneyRequest request);
    }

    public class BankAccountService : IBankAccountService
    {
        private BankAccount? DataSetToBankAccountParser(DataSet result)
        {
            if (result is null) return null;
            DataRow row = result.Tables[0].Rows[0];
            return DataRowToBankAccountParser(row);
        }

        private BankAccount? DataRowToBankAccountParser(DataRow row)
        {
            BankAccount bankAccount = new()
            {
                AccountID = Guid.Parse(row["AccountID"].ToString()),
                OwnerCustomerID = Guid.Parse(row["OwnerCustomerID"].ToString()),
                Balance = decimal.Parse(row["Balance"].ToString()),
                IBAN = row["IBAN"].ToString(),
                CreatedAt = DateTime.Parse(row["CreatedAt"].ToString())
            };

            return bankAccount;
        }

        public async Task<BankAccount> CreateBankAccountForCustomer(CreateBankAccountRequest request)
        {
            var result = BankAccountSP.CreateBankAccount(request);
            return DataSetToBankAccountParser(result);
        }

        public async Task<BankAccount> GetBankAccountByID(Guid accountID)
        {
            var result = await BankAccountSP.GetBankAccountByID(accountID);
            return DataSetToBankAccountParser(result);
        }

        public async Task<IEnumerable<BankAccount>> GetCustomerBankAccounts(Guid customerID)
        {
            List<BankAccount> bankAccounts = new();
            var result = await BankAccountSP.GetBankAccountsByCustomerID(customerID);
            foreach(DataRow row in result.Tables[0].Rows) 
            {
                try
                {
                    bankAccounts.Add(DataRowToBankAccountParser(row));
                }
                catch { }
            }

            return bankAccounts;
        }

        public BankAccount DepositMoneyToAccount(DepositMoneyRequest request)
        {
            var result = BankAccountSP.DepositMoney(request);
            return DataSetToBankAccountParser(result);
        }
    }
}
