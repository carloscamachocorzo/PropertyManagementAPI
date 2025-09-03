using Million.PropertyManagement.Application.Dtos.Property;
using Swashbuckle.AspNetCore.Filters;

namespace Million.PropertyManagement.Api.SwaggerExamples
{
    /// <summary>
    /// Proveedor de ejemplo para el DTO <see cref="CreatePropertyResponseDto"/>, utilizado en la documentación de la API.
    /// </summary>
    public class CreatePropertyResponseDtoExample : IExamplesProvider<CreatePropertyResponseDto>
    {
        /// <summary>
        /// Devuelve un ejemplo predefinido de <see cref="CreatePropertyResponseDto"/> con datos simulados.
        /// </summary>
        public CreatePropertyResponseDto GetExamples()
        {
            return new CreatePropertyResponseDto
            {
                Id = 1,
                Name = "Hotel Central",
                Address = "Cra 45 # 67-89, Bogotá",
                Price = 200000,
                Messages = new List<string> { "Propiedad creada exitosamente" }

            };
        }
    }
}
