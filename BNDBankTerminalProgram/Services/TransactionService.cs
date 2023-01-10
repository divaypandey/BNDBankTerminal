using BND_Core.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BNDBankTerminalProgram.Services
{
    internal class TransactionService
    {
        public async Task<Transaction> TransferMoney(CreateTransactionRequest request)
        {
            HttpClient client = new();
            var result = await client.PostAsync("http://localhost:5221/api/Transaction/TransferMoney", JsonContent.Create(request));
            string json = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Transaction>(json);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCustomerID(Guid customerID)
        {
            HttpClient client = new();
            var json = await client.GetStringAsync($"http://localhost:5221/api/Transaction/GetTransactionsForCustomerID/{customerID}");
            return JsonConvert.DeserializeObject<IEnumerable<Transaction>>(json);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountID(Guid accountID)
        {
            HttpClient client = new();
            var json = await client.GetStringAsync($"http://localhost:5221/api/Transaction/GetTransactionsForAccountID/{accountID}");
            return JsonConvert.DeserializeObject<IEnumerable<Transaction>>(json);
        }
    }
}
