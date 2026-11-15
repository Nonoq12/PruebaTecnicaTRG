using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(options);

            MongoClient = new MongoClient(options.Value.ConnectionString);
            RegisterBsonClasses();
        }

        public MongoClient MongoClient { get; }

        public static void RegisterBsonClasses()
        {
            RegisterClassMap<Alquiler>();
            RegisterClassMap<Vehiculo>();
            RegisterClassMap<Cliente>();
        }

        private static void RegisterClassMap<T>()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(T)))
            {
                return;
            }

            BsonClassMap.RegisterClassMap<T>(classMap =>
            {
                classMap.AutoMap();
                classMap.SetIgnoreExtraElements(true);
            });
        }
    }
}
