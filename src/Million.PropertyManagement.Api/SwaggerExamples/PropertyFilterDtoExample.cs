using Million.PropertyManagement.Application.Dtos.Property;
using Swashbuckle.AspNetCore.Filters;

namespace Million.PropertyManagement.Api.SwaggerExamples
{
    /// <summary>
    /// Proveedor de ejemplo para el DTO <see cref="PropertyFilterDto"/>, utilizado para ilustrar cómo enviar filtros de búsqueda en la API.
    /// </summary>
    public class PropertyFilterDtoExample : IExamplesProvider<PropertyFilterDto>
    {
        /// <summary>
        /// Devuelve un ejemplo predefinido de <see cref="PropertyFilterDto"/> con filtros aplicables a propiedades.
        /// </summary>
        public PropertyFilterDto GetExamples()
        {
            return new PropertyFilterDto
            {
                Name = "hotel",
                MinPrice = 100000,
                MaxPrice = 300000,
                PageNumber = 1,
                PageSize = 10
            };
        }
    }
}
