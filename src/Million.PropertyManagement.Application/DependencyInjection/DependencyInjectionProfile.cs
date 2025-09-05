using Microsoft.Extensions.DependencyInjection;
using Million.PropertyManagement.Application.Automapper;
using Million.PropertyManagement.Application.Events;
using Million.PropertyManagement.Application.Services;
using Million.PropertyManagement.Application.Services.Interfaces;
using Million.PropertyManagement.Application.Strategies;
using Million.PropertyManagement.Application.Strategies.Interfaces;
using Million.PropertyManagement.Domain.Events;
using Million.PropertyManagement.Domain.Interfaces;
using Million.PropertyManagement.Domain.Notifications;
using Million.PropertyManagement.Infrastructure.Events.Handlers;
using Million.PropertyManagement.Infrastructure.Notifications;
using Million.PropertyManagement.Infrastructure.Repositories;
using Million.PropertyManagement.Infrastructure.Security;

namespace Million.PropertyManagement.Application.DependencyInjection
{
    public static class DependencyInjectionProfile
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registrar AutoMapper
            services.AddAutoMapper(typeof(GlobalMapperProfile));
            // Registrar servicios de la capa Application            
            services.AddScoped<IPropertyAppService, PropertyAppService>();
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPropertyImageAppService, PropertyImageAppService>();
            // Registrar servicios de la capa Domain
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            //Strategias
            services.AddScoped<IPropertyFilterStrategy, NameFilterStrategy>();
            services.AddScoped<IPropertyFilterStrategy, PriceFilterStrategy>();
            // Dispatcher de eventos
            // Registrar dispatcher
            services.AddScoped<IEventDispatcher, EventDispatcher>();

            // Registrar handlers
            services.AddScoped<IEventHandler<PropertyCreatedEvent>, PropertyNotificationHandler>();
            services.AddScoped<IEventHandler<PropertyCreatedEvent>, PropertyAuditHandler>();
            // Agregar más handlers aquí

            // Servicio de correo
            services.AddScoped<IEmailService, EmailService>();


            return services;
        }
    }
}
