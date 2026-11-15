using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            bool isDevelopment)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            MongoService.RegisterBsonClasses();

            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();

                var connectionString = configuration["MongoDb:ConnectionString"]
                                       ?? "mongodb://admin:password123@localhost:27017/?authSource=admin";
                return new MongoClient(connectionString);
            });

            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var configuration = sp.GetRequiredService<IConfiguration>();
                var databaseName = configuration["MongoDb:MongoDbDatabaseName"] ?? "GtMotiveDb";
                return client.GetDatabase(databaseName);
            });

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            if (!isDevelopment)
            {
                services.AddScoped<ITelemetry, AppTelemetry>();
            }
            else
            {
                services.AddScoped<ITelemetry, NoOpTelemetry>();
            }

            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAlquilerRepository, AlquilerRepository>();

            return new InfrastructureBuilder(services);
        }

        private sealed class InfrastructureBuilder(IServiceCollection services) : IInfrastructureBuilder
        {
            public IServiceCollection Services { get; } = services;
        }
    }
}
