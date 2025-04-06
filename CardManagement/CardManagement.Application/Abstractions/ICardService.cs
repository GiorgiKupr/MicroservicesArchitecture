using CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Application.Abstractions
{
    public interface ICardService
    {
        public Task ActivateCard(Guid Id);
        public Task DeactivateCard(Guid Id);
        public Task CreateCard(string cardHolderName, string cardType);
    }
}
