using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Application.DTOs
{
    public class CreateCardRequest
    {
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
    }

}
