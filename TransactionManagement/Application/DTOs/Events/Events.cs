using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Events
{
    public class CardActivated
    {
        public Guid CardId { get; set; }
    }
    public class CardBlocked
    {
        public Guid CardId { get; set; }
    }
}
