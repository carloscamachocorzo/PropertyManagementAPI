using Million.PropertyManagement.Infrastructure;

namespace Million.PropertyManagement.Application.Strategies.Interfaces
{
    /// <summary>
    /// Contrato para aplicar filtros sobre propiedades.
    /// Es genérico porque no conoce los DTOs de Application.
    /// </summary>
    public interface IPropertyFilterStrategy<TFilter>
    {
        IQueryable<Property> Apply(IQueryable<Property> query, TFilter filter);
    }
}
