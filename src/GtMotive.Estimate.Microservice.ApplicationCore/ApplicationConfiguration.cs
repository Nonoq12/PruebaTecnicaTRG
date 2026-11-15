using System;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using GtMotive.Estimate.Microservice.ApplicationCore.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // 1. Registrar todos los validadores de este ensamblado automáticamente
            services.AddValidatorsFromAssembly(typeof(ApplicationConfiguration).Assembly);

            // 2. Registrar el PipelineBehavior en el contenedor de MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
