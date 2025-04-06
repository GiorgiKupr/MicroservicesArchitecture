using Application.Abstraction;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly ICapPublisher _capPublisher;

        public EventDispatcher(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        public async Task PublishAsync<TEvent>(string topicName, TEvent eventData)
        {
            await _capPublisher.PublishAsync(topicName, eventData);
        }
    }
}
