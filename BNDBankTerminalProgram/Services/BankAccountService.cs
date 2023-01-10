using BND_Core.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections;
using System;
using System.Collections.Generic;

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

        public async Task<BankAccount> DepositMoney(DepositMoneyRequest request)
        {
            HttpClient client = new();
            var result = await client.PostAsync("http://localhost:5221/api/BankAccount/DepositToAccount", JsonContent.Create(request));
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BankAccount>(json);
        }

        public async Task<IEnumerable<BankAccount>> GetBankAccountsForCustomer(Guid customerID)
        {
            HttpClient client = new();
            var json = await client.GetStringAsync($"http://localhost:5221/api/BankAccount/GetBankAccountsForCustomer/{customerID}");
            return JsonConvert.DeserializeObject<IEnumerable<BankAccount>>(json);
        }
    }
}
