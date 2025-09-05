using Microsoft.Extensions.Logging;
using Million.PropertyManagement.Domain.Events;

namespace Million.PropertyManagement.Infrastructure.Events.Handlers
{
    public class PropertyAuditHandler : IEventHandler<PropertyCreatedEvent>
    {
        private readonly ILogger<PropertyAuditHandler> _logger;

        public PropertyAuditHandler(ILogger<PropertyAuditHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(PropertyCreatedEvent domainEvent)
        {
            _logger.LogInformation($"[AUDITORÍA] Propiedad creada: Id={domainEvent.PropertyId}, Nombre={domainEvent.Name}, Fecha={domainEvent.OccurredOn}");
            return Task.CompletedTask;
        }
    }
}
