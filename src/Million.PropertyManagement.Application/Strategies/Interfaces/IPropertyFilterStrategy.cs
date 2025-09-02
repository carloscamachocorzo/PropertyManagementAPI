using Million.PropertyManagement.Application.Dtos.Property;
using Million.PropertyManagement.Infrastructure;

namespace Million.PropertyManagement.Application.Strategies.Interfaces
{
    public interface IPropertyFilterStrategy
    {
        IQueryable<Property> Apply(IQueryable<Property> query, PropertyFilterDto filter);
    }
}
