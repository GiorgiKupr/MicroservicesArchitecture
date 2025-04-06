using Application.Abstraction;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Transaction.API.Controllers
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
        public async Task<IActionResult> ProcessTransaction([FromBody] TransactionRequestDto model)
        {
            await _transactionService.ProcessTransaction(model);
            return Ok();
        }
    }
}
