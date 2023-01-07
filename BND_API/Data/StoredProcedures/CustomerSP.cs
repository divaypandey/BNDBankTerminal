using BND_API.Models;
using System.Data;

namespace BND_API.Data.StoredProcedures
{
    internal static class CustomerSP
    {
        internal static DataSet CreateCustomer(CreateCustomerRequest request)
        {
            return new DataAccessHelper().HandleSQL($"INSERT INTO CustomerTable (CustomerID, FirstName, LastName, ContactNumber, Email, PrimaryAddress, CitizenID) OUTPUT INSERTED.CustomerID VALUES (NEWID(), '{request.FirstName}', '{request.LastName}', '{request.ContactNumber}', '{request.Email}', '{request.PrimaryAddress}', '{request.CitizenID}')"); //sanitise?
        }
    }
}
