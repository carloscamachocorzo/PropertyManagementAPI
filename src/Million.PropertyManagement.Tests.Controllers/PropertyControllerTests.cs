using Microsoft.AspNetCore.Mvc;
using Million.PropertyManagement.Api.Controllers;
using Million.PropertyManagement.Application.Dtos.Property;
using Million.PropertyManagement.Application.Services.Interfaces;
using Million.PropertyManagement.Common;
using Moq;

namespace Million.PropertyManagement.Tests.Controllers
{
    public class PropertyControllerTests
    {
        [Fact]
        public async Task GetPropertiesAsync_Should_Return_Ok_With_Properties()
        {
            // Arrange: Creamos mock de IPropertyAppService e IPropertyImageAppService
            var mockPropertyAppService = new Mock<IPropertyAppService>();
            var mockPropertyImageAppService = new Mock<IPropertyImageAppService>();

            // Simulamos que GetPropertiesAsync devuelva una lista de propiedades
            var properties = new List<PropertyDto>
            {
                new PropertyDto { Name = "Property 1", Price = 1000 },
                new PropertyDto { Name = "Property 2", Price = 2000 }
            };

            // Configuramos el mock para que devuelva esta lista cuando se llame con cualquier PropertyFilterDto
            //mockPropertyAppService.Setup(service => service.GetPropertiesAsync(It.IsAny<PropertyFilterDto>()))
            //                      .ReturnsAsync(properties);
            var expectedPagedResult = new PagedResult<PropertyDto>(
                   properties,
                   totalCount: properties.Count,
                   pageNumber: 1,
                   pageSize: properties.Count
               );

            mockPropertyAppService = new Mock<IPropertyAppService>();
            mockPropertyAppService.Setup(service => service.GetPropertiesAsync(It.IsAny<PropertyFilterDto>()))
                                   .ReturnsAsync(expectedPagedResult);

            // Creamos una instancia del PropertiesController e inyectamos los mocks
            var controller = new PropertiesController(mockPropertyAppService.Object, mockPropertyImageAppService.Object);

            // Creamos un filtro simulado que pasaremos al método
            var filter = new PropertyFilterDto
            {
                Name = "Hotel",
                MinPrice = 0,
                MaxPrice = 5000
            };

            // Act: Llamamos al método que estamos probando, pasando el filtro
            var result = await controller.GetPropertiesWithFilters(filter);

            // Assert: Verificamos que el resultado sea OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result);

            // Verificamos que el contenido del OkObjectResult es PagedResult<PropertyDto>
            var returnedProperties = Assert.IsType<PagedResult<PropertyDto>>(okResult.Value);

            // Convertimos a lista para poder acceder por índice
            var propertiesList = returnedProperties.Items.ToList();

            // Verificaciones
            Assert.Equal(2, returnedProperties.TotalCount);
            Assert.Equal("Property 1", propertiesList[0].Name);  // Accedemos por índice en la lista
            Assert.Equal("Property 2", propertiesList[1].Name);  // Accedemos por índice en la lista
        }


        [Fact]
        public async Task GetPropertiesWithFilters_Should_Return_NotFound_When_No_Properties()
        {
            // Arrange
            var mockPropertyAppService = new Mock<IPropertyAppService>();
            var mockPropertyImageAppService = new Mock<IPropertyImageAppService>();

            // ¡IMPORTANTE! La lista debe estar VACÍA
            var emptyList = new List<PropertyDto>(); // Lista VACÍA

            var emptyPagedResult = new PagedResult<PropertyDto>(
                emptyList,          // ← LISTA VACÍA
                totalCount: 0,      // TotalCount = 0
                pageNumber: 1,
                pageSize: 10
            );

            mockPropertyAppService.Setup(service => service.GetPropertiesAsync(It.IsAny<PropertyFilterDto>()))
                                   .ReturnsAsync(emptyPagedResult);

            var controller = new PropertiesController(mockPropertyAppService.Object, mockPropertyImageAppService.Object);
            var filter = new PropertyFilterDto { Name = "Hotel", MinPrice = 0, MaxPrice = 5000 };

            // Act
            var result = await controller.GetPropertiesWithFilters(filter);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            var value = notFoundResult.Value;
            var messageProperty = value.GetType().GetProperty("message");
            Assert.NotNull(messageProperty);

            var messageValue = messageProperty.GetValue(value) as string;
            Assert.Equal("No se encontraron propiedades que coincidan con los filtros aplicados.", messageValue);
        }

        [Fact]
        public async Task GetPropertiesAsync_WithPagination_ReturnsPartialResults()
        {
            // Arrange
            var allProperties = new List<PropertyDto>
            {
                new PropertyDto { Name = "Property 1" },
                new PropertyDto { Name = "Property 2" },
                new PropertyDto { Name = "Property 3" },
                new PropertyDto { Name = "Property 4" },
                new PropertyDto { Name = "Property 5" }
            };

            var page2Properties = new List<PropertyDto> { allProperties[2], allProperties[3] };

            var expectedPagedResult = new PagedResult<PropertyDto>(
                page2Properties,
                totalCount: allProperties.Count,
                pageNumber: 2,
                pageSize: 2
            );

            var mockPropertyAppService = new Mock<IPropertyAppService>();
            mockPropertyAppService.Setup(service => service.GetPropertiesAsync(It.IsAny<PropertyFilterDto>()))
                                   .ReturnsAsync(expectedPagedResult);

            // Act
            var filter = new PropertyFilterDto { PageNumber = 2, PageSize = 2 };
            var result = await mockPropertyAppService.Object.GetPropertiesAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count());
            Assert.Equal(5, result.TotalCount);
            Assert.Equal(2, result.PageNumber);
            Assert.Equal(2, result.PageSize);
        }
    }
}
