using Million.PropertyManagement.Application.Dtos.Property;
using Million.PropertyManagement.Application.Strategies.Interfaces;
using Million.PropertyManagement.Infrastructure;

namespace Million.PropertyManagement.Application.Strategies
{
    /// <summary>
    /// Contexto para aplicar estrategias de filtrado a propiedades.
    /// </summary>
    public class PropertyFilterContext
    {
        private readonly IEnumerable<IPropertyFilterStrategy> _strategies;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PropertyFilterContext"/>.
        /// </summary>
        /// <param name="strategies">
        /// Colección de estrategias de filtrado que se aplicarán a las propiedades.
        /// </param>
        public PropertyFilterContext(IEnumerable<IPropertyFilterStrategy> strategies)
        {
            _strategies = strategies;
        }
        /// <summary>
        /// Aplica todas las estrategias de filtrado al conjunto de propiedades proporcionado.
        /// </summary>
        /// <param name="query">
        /// Consulta de propiedades sobre la cual se aplicarán los filtros.
        /// </param>
        /// <param name="filter">
        /// Objeto que contiene los criterios de filtrado.
        /// </param>
        /// <returns>
        /// Una nueva consulta <see cref="IQueryable{Property}"/> con todos los filtros aplicados.
        /// </returns>
        public IQueryable<Property> ApplyAll(IQueryable<Property> query, PropertyFilterDto filter)
        {
            foreach (var strategy in _strategies)
            {
                query = strategy.Apply(query, filter);
            }
            return query;
        }
    }
}
