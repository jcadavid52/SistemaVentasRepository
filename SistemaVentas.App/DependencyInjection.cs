using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SistemaVentas.App.Extensions;
using SistemaVentas.Domain.Abstractions;

namespace SistemaVentas.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            var _appServices = AppDomain.CurrentDomain.GetAssemblies()
         .Where(assembly =>
         {
             return assembly.FullName is null || assembly.FullName.Contains("App", StringComparison.OrdinalIgnoreCase);
         })
         .SelectMany(assembly => assembly.GetTypes())
         .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(ApplicationServiceAttribute)));

            foreach (var appService in _appServices)
            {
                services.AddTransient(appService);
            }

            return services;
        }
    }
}
