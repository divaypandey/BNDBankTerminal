using BND_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public Transaction MakeTransaction (CreateTransactionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
