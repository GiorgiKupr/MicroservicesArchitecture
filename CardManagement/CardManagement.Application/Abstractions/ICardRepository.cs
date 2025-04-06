using CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Application.Abstractions
{
    public interface ICardRepository
    {
        public Task<Card> GetById(Guid id);
        public Task<IEnumerable<Card>> GetAll();
        public void Update(Card card);
        public void Delete(Card card);
        public Task<Guid> Add(Card card);
    }
}
