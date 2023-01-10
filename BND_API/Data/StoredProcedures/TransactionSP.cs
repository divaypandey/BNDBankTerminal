using BND_Core.Models;
using System.Data;

namespace BND_API.Data.StoredProcedures
{
    internal class TransactionSP
    {
        private static readonly string TABLE_NAME = "TransactionsTable";

        internal static async Task<DataSet> GetTransactionsByAccountID(Guid accountID)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE FromAccountID = '{accountID}' OR ToAccountID = '{accountID}' ORDER BY AttemptedOn DESC");
        }
        internal static async Task<DataSet> GetTransactionsByCustomerID(Guid customerID)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE AccountID = '{customerID}' ORDER BY AttemptedOn DESC");
        }

        internal static DataSet TransferMoney(CreateTransactionRequest request)
        {
            decimal amount = Math.Max(0, request.Amount);
            return new DataAccessHelper().HandleSQL(@$"
DECLARE @FROMBAL float;
SET @FROMBAL = (SELECT Balance FROM BankAccountsTable WHERE AccountID = '{request.FromAccountID}');
IF(@FROMBAL >= {amount})
	BEGIN
		UPDATE BankAccountsTable SET Balance = (Balance - {amount}) WHERE AccountID = '{request.FromAccountID}';
		UPDATE BankAccountsTable SET Balance = (Balance + {amount}) WHERE AccountID = '{request.ToAccountID}';
        INSERT INTO {TABLE_NAME} OUTPUT INSERTED.* (TransactionID, AttemptedOn, FromAccountID, ToAccountID, Amount, WasSuccessful) VALUES (NEWID(), '{DateTime.UtcNow}', '{request.FromAccountID}', '{request.ToAccountID}', {amount}, 1);
	END
ELSE 
    BEGIN
        INSERT INTO {TABLE_NAME} OUTPUT INSERTED.* (TransactionID, AttemptedOn, FromAccountID, ToAccountID, Amount, WasSuccessful) VALUES (NEWID(), '{DateTime.UtcNow}', '{request.FromAccountID}', '{request.ToAccountID}', {amount}, 0);
    END");
        }
    }
}
