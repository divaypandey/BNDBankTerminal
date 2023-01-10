using BND_Core.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BNDBankTerminalProgram.Services
{
    internal class BankAccountService
    {
        public async Task<BankAccount> CreateBankAccount(CreateBankAccountRequest request)
        {
            HttpClient client = new();
            var result = await client.PostAsync("http://localhost:5221/api/BankAccount", JsonContent.Create(request));
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BankAccount>(json);
        }
    }
}
