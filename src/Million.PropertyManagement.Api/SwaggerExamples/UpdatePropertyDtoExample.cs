using Million.PropertyManagement.Application.Dtos.Property;
using Swashbuckle.AspNetCore.Filters;

namespace Million.PropertyManagement.Api.SwaggerExamples
{
    /// <summary>
    /// Proveedor de ejemplo para la actualización de propiedades (PropertyUpdateDto).
    /// Esta clase se utiliza para mostrar un ejemplo en la documentación Swagger.
    /// </summary>
    public class UpdatePropertyDtoExample : IExamplesProvider<PropertyUpdateDto>
    {
        public PropertyUpdateDto GetExamples()
        {
            return new PropertyUpdateDto
            {
                CodeInternal = "P001",
                Name = "Hotel Central Renovado",
                Price = 220000,
                Address = "Cra 45 # 67-89, Bogotá",
                Year = 2025
            };
        }
    }
}
