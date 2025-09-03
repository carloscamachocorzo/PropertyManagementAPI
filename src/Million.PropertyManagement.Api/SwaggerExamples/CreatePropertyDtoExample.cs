using Million.PropertyManagement.Application.Dtos.Property;
using Swashbuckle.AspNetCore.Filters;

namespace Million.PropertyManagement.Api.SwaggerExamples
{
    /// <summary>
    /// Proveedor de ejemplo para el DTO <see cref="PropertyDto"/>, utilizado en la documentación de la API.
    /// </summary>
    public class CreatePropertyDtoExample : IExamplesProvider<PropertyDto>
    {
        /// <summary>
        /// Devuelve un ejemplo predefinido de <see cref="PropertyDto"/> para propósitos de documentación.
        /// </summary>
        public PropertyDto GetExamples()
        {
            return new PropertyDto
            {
                Name = "Hotel Central",
                Price = 200000,
                Address = "Cra 45 # 67-89, Bogotá",
                CodeInternal = "P001",
                Year = 2025,
                IdOwner = 1
            };
        }
    }
}
