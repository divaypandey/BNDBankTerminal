using BND_API.Data.StoredProcedures;
using BND_API.Models;
using System.Data;

namespace BND_API.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByID(Guid customerID);
        Customer CreateCustomer(CreateCustomerRequest request);
        Task<Customer> GetCustomerByEmail(string email);
    }

    public class CustomerService : ICustomerService
    {
        private Customer? DataSetToCustomerParser(DataSet result)
        {
            if (result is null) return null;

            DataRow row = result.Tables[0].Rows[0];

            Customer customer = new()
            {
                CustomerID = Guid.Parse(row["CustomerID"].ToString()),
                FirstName = row["FirstName"].ToString(),
                ContactNumber = row["ContactNumber"].ToString(),
                PrimaryAddress = row["PrimaryAddress"].ToString(),
                CitizenID = row["CitizenID"].ToString(),
                Email = row["Email"].ToString()
            };
            if (!row.IsNull("LastName")) customer.LastName = row["LastName"].ToString();

            return customer;
        }

        public Customer? CreateCustomer(CreateCustomerRequest request)
        {
            request.Email = request.Email.Trim().ToLower();
            DataSet result = CustomerSP.CreateCustomer(request);

            return DataSetToCustomerParser(result);
        }

        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            DataSet result = await CustomerSP.GetCustomerByEmail(email);
            return DataSetToCustomerParser(result);
        }

        public async Task<Customer?> GetCustomerByID(Guid customerID)
        {
            DataSet result = await CustomerSP.GetCustomerByID(customerID);
            return DataSetToCustomerParser(result);
        }
    }
}
