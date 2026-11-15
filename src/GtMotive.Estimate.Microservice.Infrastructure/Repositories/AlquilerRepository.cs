using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de Alquileres.
    /// </summary>
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly IMongoCollection<Alquiler> _alquilerCollection;

        // Recibe el servicio de Mongo ya configurado
        public AlquilerRepository(IMongoDatabase database)
        {
            ArgumentNullException.ThrowIfNull(database);
            _alquilerCollection = database.GetCollection<Alquiler>("Alquileres");
        }

        public async Task AgregarAlquilerAsync(Alquiler alquiler)
        {
            await _alquilerCollection.InsertOneAsync(alquiler);
        }

        public Task<Alquiler> ObtenerAlquilerPorIdAsync(Guid id)
        {
            return _alquilerCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Alquiler>> ObtenerTodosAlquilersAsync()
        {
            var cursor = await _alquilerCollection.FindAsync(_ => true);
            return await cursor.ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> ObtenerPendientesAlquilersAsync()
        {
            var cursor = await _alquilerCollection.FindAsync(v => !v.Devuelto);
            return await cursor.ToListAsync();
        }

        public async Task<IEnumerable<Alquiler>> ObtenerTerminadosAlquilersAsync()
        {
            var cursor = await _alquilerCollection.FindAsync(v => v.Devuelto);
            return await cursor.ToListAsync();
        }

        public async Task BorrarAlquilerAsync(Alquiler alquiler)
        {
            await _alquilerCollection.DeleteOneAsync(v => v.Id == alquiler.Id);
        }

        public async Task ActualizarAlquilerAsync(Alquiler alquiler)
        {
            await _alquilerCollection.ReplaceOneAsync(v => v.Id == alquiler.Id, alquiler);
        }
    }
}
