using Microsoft.Extensions.DependencyInjection;
using Million.PropertyManagement.Domain.Events;

namespace Million.PropertyManagement.Application.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<T>(T domainEvent) where T : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IEventHandler<T>>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(domainEvent);
            }
        }
    }
}
