using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TransactionRequestDto
    {
        public Guid CardId { get;  set; }  // Card ID associated with this transaction
        public decimal Amount { get;  set; }  // Transaction amount
        public string Type { get;  set; }  // Debit or Credit transaction
        public string Description { get;  set; }  // Description for the transaction (e.g., purchase, deposit)

    }
}
