using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Abstraction
{
    public interface ITransactionRepository
    {
        public Task<Transaction> GetById(Guid id);
        public Task<IEnumerable<Transaction>> GetAll();
        public void Update(Transaction card);
        public void Delete(Transaction card);
        public Task<Guid> Add(Transaction card);
    }
}
