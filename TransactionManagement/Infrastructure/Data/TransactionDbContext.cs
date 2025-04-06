using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            
        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
