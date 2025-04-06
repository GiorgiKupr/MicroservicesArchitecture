using CardManagement.Application.Abstractions;
using CardManagement.Application.DTOs;
using CardManagement.Domain;

namespace CardManagement.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IEventDispatcher _producer;
        public CardService(ICardRepository cardRepository, IEventDispatcher producer)
        {
            _cardRepository = cardRepository;
            _producer = producer;
        }
        public async Task ActivateCard(Guid Id)
        {
            var card = await _cardRepository.GetById(Id);
            if (card == null)
            {
                card.IsActive = true;
                card.IsBlocked = false;
                _cardRepository.Update(card);
            }

            var cardActivatedEvent = new CardActivated { CardId = card.CardId };
            await _producer.PublishAsync("card.activated", cardActivatedEvent);
          
        }

        public async Task CreateCard(string cardHolderName, string cardType)
        {
            var card = new Card 
            { 
              CardHolderName = cardHolderName,
              CardType = cardType ,
              IsActive = true,
              IsBlocked = false
            };
            var guid = _cardRepository.Add(card);
            var eventCreated = new CardCreated { CardId = card.CardId, CardHolderName = card.CardHolderName, CardType = card.CardType };
            await _producer.PublishAsync("card.crated", eventCreated);
        }

        public async Task DeactivateCard(Guid Id)
        {
            var card = await _cardRepository.GetById(Id);
            if (card == null)
            {
                card.IsActive = false;
                card.IsBlocked = true;
                _cardRepository.Update(card);
            }
            var cardDeactivatedEvent = new CardBlocked { CardId = card.CardId };
            await _producer.PublishAsync("card.deactivated", cardDeactivatedEvent);
        }
    }
}
