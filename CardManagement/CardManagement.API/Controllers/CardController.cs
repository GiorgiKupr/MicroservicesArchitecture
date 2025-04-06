using CardManagement.Application.Abstractions;
using CardManagement.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [Route("activate/{guid}")]
        public async Task<IActionResult> ActivateCard(Guid guid) 
        {
            await _cardService.ActivateCard(guid);
            return Ok($"card with id - {guid} has been activated");
        }

        [HttpPost]
        [Route("deactivate/{guid}")]
        public async Task<IActionResult> DeActivateCard(Guid guid)
        {
            await _cardService.DeactivateCard(guid);
            return Ok($"card with id - {guid} has been DeActivated");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardRequest request)
        {
            await _cardService.CreateCard(request.CardHolderName, request.CardType);
            return Ok();
        }
    }
}
