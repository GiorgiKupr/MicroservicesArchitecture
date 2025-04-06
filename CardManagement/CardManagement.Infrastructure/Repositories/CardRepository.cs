using CardManagement.Application.Abstractions;
using CardManagement.Domain;
using CardManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardManagementDbContext _dbcontext;
        public CardRepository(CardManagementDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Delete(Card card)
        {
           _dbcontext.Remove(card);
           _dbcontext.SaveChanges();
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _dbcontext.Cards.ToListAsync();
        }
        public async Task<Card> GetById(Guid id)
        {
            return await _dbcontext.Cards.FirstOrDefaultAsync(a => a.CardId == id);
        }

        public void Update(Card card)
        {
            _dbcontext.Update(card);
            _dbcontext.SaveChanges();
        }

        public async Task<Guid> Add(Card card) 
        {
            await _dbcontext.AddAsync(card);
            await _dbcontext.SaveChangesAsync();
            return card.CardId;
        }

    }
}
