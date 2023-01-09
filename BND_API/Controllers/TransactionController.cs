using BND_API.Models;
using BND_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<Transaction> MakeTransaction(CreateTransactionRequest request)
        {
            return await _transactionService.CreateTransaction(request);
        }

        [HttpGet("GetTransactionsForAccountID/{accountID}")]
        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountID(Guid accountID)
        {
            return await _transactionService.GetAllTransactionsForAccountID(accountID);
        }

        [HttpGet("GetTransactionsForCustomerID/{customerID}")]
        public async Task<IEnumerable<Transaction>> GetTransactionsForCustomerID(Guid customerID)
        {
            return await _transactionService.GetAllTransactionsForCustomerID(customerID);
        }
    }
}
