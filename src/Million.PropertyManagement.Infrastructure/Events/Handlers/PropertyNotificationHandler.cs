using Microsoft.Extensions.Logging;
using Million.PropertyManagement.Domain.Events;
using Million.PropertyManagement.Domain.Notifications;

namespace Million.PropertyManagement.Infrastructure.Events.Handlers
{
    public class PropertyNotificationHandler : IEventHandler<PropertyCreatedEvent>
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<PropertyNotificationHandler> _logger;

        public PropertyNotificationHandler(IEmailService emailService, ILogger<PropertyNotificationHandler> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task HandleAsync(PropertyCreatedEvent domainEvent)
        {
            try
            {
                string subject = "Nueva propiedad registrada";
                string body = $"Se creó una nueva propiedad con Id={domainEvent.PropertyId}, Nombre={domainEvent.Name}, Fecha={domainEvent.OccurredOn}";

                //  Enviar correo
                await _emailService.SendEmailAsync("ccamachocorzo@gmail.com", subject, body);

                _logger.LogInformation($"Correo enviado correctamente para la propiedad {domainEvent.PropertyId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enviando correo de notificación");
            }
        }
    }
}
