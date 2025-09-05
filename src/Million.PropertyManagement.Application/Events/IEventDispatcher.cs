using Million.PropertyManagement.Domain.Events;

namespace Million.PropertyManagement.Application.Events
{
    public interface IEventDispatcher
    {
        /// <summary>
        /// Despacha un evento de dominio al conjunto de manejadores registrados que implementan <see cref="IEventHandler{T}"/>.
        /// </summary>
        /// <typeparam name="T">Tipo del evento de dominio que implementa <see cref="IDomainEvent"/>.</typeparam>
        /// <param name="domainEvent">Instancia del evento de dominio que se desea despachar.</param>
        /// <returns>Una tarea que representa la operación asincrónica de ejecución de los manejadores.</returns>

        Task DispatchAsync<T>(T domainEvent) where T : IDomainEvent;
    }

}
