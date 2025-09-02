using Million.PropertyManagement.Application.Dtos.Property;
using Million.PropertyManagement.Application.Strategies.Interfaces;
using Million.PropertyManagement.Infrastructure;

namespace Million.PropertyManagement.Application.Strategies
{
    public class NameFilterStrategy : IPropertyFilterStrategy
    {
        public IQueryable<Property> Apply(IQueryable<Property> query, PropertyFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));
            return query;
        }
    }
}
