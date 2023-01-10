using BND_API.Data.StoredProcedures;
using BND_Core.Models;
using System.Data;

namespace BND_API.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsForAccountID(Guid accountID);
        Task<IEnumerable<Transaction>> GetAllTransactionsForCustomerID(Guid customerID);
        Transaction TransferMoney(CreateTransactionRequest request);

    }
    public class TransactionService : ITransactionService
    {
        private Transaction? DataRowToTransactionParser(DataRow row)
        {
            Transaction transaction = new()
            {
                TransactionID = Guid.Parse(row["TransactionID"].ToString()),
                FromAccountID = Guid.Parse(row["FromAccountID"].ToString()),
                ToAccountID = Guid.Parse(row["ToAccountID"].ToString()),
                Amount = decimal.Parse(row["Amount"].ToString()),
                AttemptedOn = DateTime.Parse(row["AttemptedOn"].ToString()),
                WasSuccessful = (bool)row["WasSuccessful"]
            };
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsForAccountID(Guid accountID)
        {
            List<Transaction> transactionList = new();
            var result = await TransactionSP.GetTransactionsByAccountID(accountID);
            foreach(DataRow row in result.Tables[0].Rows)
            {
                try
                {
                    transactionList.Add(DataRowToTransactionParser(row));
                }
                catch { }
            }

            return transactionList;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsForCustomerID(Guid customerID)
        {
            List<Transaction> transactionList = new();
            var result = await TransactionSP.GetTransactionsByCustomerID(customerID);
            foreach (DataRow row in result.Tables[0].Rows)
            {
                try
                {
                    transactionList.Add(DataRowToTransactionParser(row));
                }
                catch { }
            }

            return transactionList;
        }

        public Transaction TransferMoney(CreateTransactionRequest request)
        {
            var result = TransactionSP.TransferMoney(request);
            return DataRowToTransactionParser(result.Tables[0].Rows[0]);
        }
    }
}
