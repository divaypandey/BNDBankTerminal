using BND_Core.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BNDBankTerminalProgram.Services
{
    internal class CustomerService
    {
        public async Task<Customer> CreateCustomer(CreateCustomerRequest request)
        {
            HttpClient client = new();
            var result = await client.PostAsync("http://localhost:5221/api/customer", JsonContent.Create(request));
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customer>(json);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            HttpClient client = new();
            var result = await client.GetAsync($"http://localhost:5221/api/customer/GetCustomerByEmail/{email.Trim().ToLower()}");
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Customer>(json);
        }
    }
}
