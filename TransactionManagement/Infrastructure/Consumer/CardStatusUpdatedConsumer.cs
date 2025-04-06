using Application.Abstraction;
using Application.DTOs.Events;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumer
{
    public class CardStatusUpdatedConsumer : ICapSubscribe
    {
        private readonly ITransactionService _transactionService;

        public CardStatusUpdatedConsumer(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [CapSubscribe("card.activated")]
        public async Task ConsumeCardUpdateEvents(CardActivated activated, CancellationToken cancellationToken)
        {
            _transactionService.HandleCardStatusChange(activated);
        }

        [CapSubscribe("card.deactivated")]
        public async Task ConsumeCardUpdateEvents(CardBlocked deactivated, CancellationToken cancellationToken)
        {
            _transactionService.HandleCardStatusChange(deactivated);
        }
    }
}
