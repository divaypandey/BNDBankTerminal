using BND_Core.Models;
using System.Data;

namespace BND_API.Data.StoredProcedures
{
    internal static class BankAccountSP
    {
        private static readonly string TABLE_NAME = "BankAccountsTable";
        internal static DataSet CreateBankAccount(CreateBankAccountRequest request) //future handling of initial balance?
        {
            return new DataAccessHelper().HandleSQL($"INSERT INTO {TABLE_NAME} (AccountID, OwnerCustomerID, Balance, IBAN, CreatedAt) OUTPUT INSERTED.* VALUES (NEWID(), '{request.OwnerCustomerID}', 0, '{request.IBAN}', '{DateTime.UtcNow}')"); //sanitise?
        }

        internal static DataSet DepositMoney(DepositMoneyRequest request)
        {
            var dataAccess = new DataAccessHelper();
            dataAccess.HandleSQL($"UPDATE {TABLE_NAME} SET BALANCE = BALANCE + {request.ActualDepositAmount} WHERE AccountID = '{request.AccountID}'");
            return dataAccess.HandleSQL($"SELECT * FROM {TABLE_NAME} WHERE AccountID = '{request.AccountID}'");
        }

        internal static async Task<DataSet> GetBankAccountByID(Guid accountID)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE AccountID = '{accountID}'");
        }

        internal static async Task<DataSet> GetBankAccountsByCustomerID(Guid customerID)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE OwnerCustomerID = '{customerID}'");
        }
    }
}