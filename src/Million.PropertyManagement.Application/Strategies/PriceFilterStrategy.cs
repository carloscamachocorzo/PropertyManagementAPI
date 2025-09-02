using Million.PropertyManagement.Application.Dtos.Property;
using Million.PropertyManagement.Application.Strategies.Interfaces;
using Million.PropertyManagement.Infrastructure;

namespace Million.PropertyManagement.Application.Strategies
{
    public class PriceFilterStrategy : IPropertyFilterStrategy
    {
        public IQueryable<Property> Apply(IQueryable<Property> query, PropertyFilterDto filter)
        {
            if (filter.MinPrice > 0)
                query = query.Where(p => p.Price >= filter.MinPrice);

            if (filter.MaxPrice > 0)
                query = query.Where(p => p.Price <= filter.MaxPrice);

            return query;
        }
    }
}
