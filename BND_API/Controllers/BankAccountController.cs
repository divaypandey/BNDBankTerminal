using BND_API.Models;
using BND_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService) 
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet("GetBankAccountByID/{accountID}")]
        public async Task<BankAccount> GetBankAccountByID(Guid accountID)
        {
            return await _bankAccountService.GetBankAccountByID(accountID);
        }

        [HttpPost]
        public async Task<BankAccount> CreateBankAccountForCustomer(CreateBankAccountRequest request)
        {
            return await _bankAccountService.CreateBankAccountForCustomer(request);
        }

        [HttpGet("GetBankAccountsForCustomer/customerID")]
        public async Task<IEnumerable<BankAccount>> GetBankAccountsForCustomer(Guid customerID)
        {
            return await _bankAccountService.GetCustomerBankAccounts(customerID);
        }
    }
}
