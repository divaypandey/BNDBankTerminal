﻿using BND_API.Data.StoredProcedures;
using BND_API.Models;
using System.Data;

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
        private BankAccount? DataSetToBankAccountParser(DataSet result)
        {
            if (result is null) return null;

            DataRow row = result.Tables[0].Rows[0];

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
