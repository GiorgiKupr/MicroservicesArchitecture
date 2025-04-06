using Application.Abstraction;
using Application.DTOs;
using Application.DTOs.Events;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IEventDispatcher _producer;

        private static Dictionary<Guid,bool> isBlocked = new Dictionary<Guid,bool>();
        public TransactionService(ITransactionRepository transactionRepository, IEventDispatcher producer)
        {
            _transactionRepository = transactionRepository;
            _producer = producer;
        }

        public async Task ProcessTransaction(TransactionRequestDto model)
        {
            var transaction = new Transaction
            {
                CardId = model.CardId,
                Amount = model.Amount,
                Type = model.Type,
                Timestamp = DateTime.Now,
                Description = model.Description
            };

            if (isBlocked.ContainsKey(model.CardId) )
            {
                if (isBlocked[model.CardId] == true)
                {
                    transaction.Status = "declined";
                    transaction.FailureReason = "card is blocked.";
                    await _producer.PublishAsync("transaction.declined", transaction);
                }
            }
            else
            {
                transaction.Status = "processed";
                await _producer.PublishAsync("transaction.processed", transaction);
            }
        }
        public void HandleCardStatusChange<T>(T card)
        {
            if (card is CardActivated cardActivated)
            {
                if (isBlocked.ContainsKey(cardActivated.CardId))
                {
                    isBlocked[cardActivated.CardId] = false;
                }
                else
                {
                    isBlocked.Add(cardActivated.CardId, false);
                }
            }
            else if (card is CardBlocked cardBlocked)
            {
                if (isBlocked.ContainsKey(cardBlocked.CardId))
                {
                    isBlocked[cardBlocked.CardId] = true;
                }
                else
                {
                    isBlocked.Add(cardBlocked.CardId, true);
                }
            }
        }
    }
}
