namespace Million.PropertyManagement.Domain.Events
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        /// <summary>
        /// Maneja el evento <see cref="PropertyCreatedEvent"/> enviando una notificación por correo electrónico.
        /// </summary>
        Task HandleAsync(T domainEvent);
    }
}
