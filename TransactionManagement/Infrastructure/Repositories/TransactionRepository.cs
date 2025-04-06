using Application.Abstraction;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly TransactionDbContext _dbcontext;
        public TransactionRepository(TransactionDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Delete(Transaction card)
        {
            _dbcontext.Remove(card);
            _dbcontext.SaveChanges();
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _dbcontext.Transactions.ToListAsync();
        }
        public async Task<Transaction> GetById(Guid id)
        {
            return await _dbcontext.Transactions.FirstOrDefaultAsync(a => a.CardId == id);
        }

        public void Update(Transaction card)
        {
            _dbcontext.Update(card);
            _dbcontext.SaveChanges();
        }

        public async Task<Guid> Add(Transaction card)
        {
            await _dbcontext.AddAsync(card);
            await _dbcontext.SaveChangesAsync();
            return card.CardId;
        }

    }
}
