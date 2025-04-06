using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction
{
    public interface ITransactionService
    {
        Task ProcessTransaction(TransactionRequestDto model);
        void HandleCardStatusChange<T>(T card);
    }
}
