using CardManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Infrastructure.Data
{
    public class CardManagementDbContext : DbContext
    {
        public CardManagementDbContext(DbContextOptions<CardManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}
