using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManagement.Application.Abstractions
{
    public interface IEventDispatcher
    {
       Task PublishAsync<TEvent>(string topicName, TEvent eventData);
    
    }
}
