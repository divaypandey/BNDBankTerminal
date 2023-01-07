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
        private Customer dataSetToCustomerParser(DataSet result)
        {
            Customer customer = new();
            //parse dataset/datarow here
            return customer;
        }




        public Customer CreateCustomer(CreateCustomerRequest request)
        {
            request.Email = request.Email.Trim().ToLower();
            DataSet result = CustomerSP.CreateCustomer(request);

            return dataSetToCustomerParser(result);
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByID(Guid customerID)
        {
            throw new NotImplementedException();
        }
    }
}
