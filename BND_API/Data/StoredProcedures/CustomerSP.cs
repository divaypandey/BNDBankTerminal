using BND_API.Models;
using System.Data;

namespace BND_API.Data.StoredProcedures
{
    internal static class CustomerSP
    {
        private static readonly string TABLE_NAME = "CustomerTable";

        internal static DataSet CreateCustomer(CreateCustomerRequest request)
        {
            return new DataAccessHelper().HandleSQL($"INSERT INTO {TABLE_NAME} (CustomerID, FirstName, LastName, ContactNumber, Email, PrimaryAddress, CitizenID) OUTPUT INSERTED.* VALUES (NEWID(), '{request.FirstName}', '{request.LastName}', '{request.ContactNumber}', '{request.Email}', '{request.PrimaryAddress}', '{request.CitizenID}')"); //sanitise?
        }

        internal static async Task<DataSet> GetCustomerByEmail(string email)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE Email = '{email.Trim().ToLower()}'");
        }

        internal static async Task<DataSet> GetCustomerByID(Guid customerID)
        {
            return await new DataAccessHelper().HandleSQLAsync($"SELECT * FROM {TABLE_NAME} WHERE CustomerID = '{customerID}'");
        }
    }
}
