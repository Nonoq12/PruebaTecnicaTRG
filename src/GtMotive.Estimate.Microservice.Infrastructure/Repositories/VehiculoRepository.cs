using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de Vehiculos.
    /// </summary>
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly IMongoCollection<Vehiculo> _vehiculosCollection;

        // Recibe el servicio de Mongo ya configurado
        public VehiculoRepository(IMongoDatabase database)
        {
            ArgumentNullException.ThrowIfNull(database);
            _vehiculosCollection = database.GetCollection<Vehiculo>("Vehiculos");
        }

        public async Task AgregarVehiculoAsync(Vehiculo vehicle)
        {
            await _vehiculosCollection.InsertOneAsync(vehicle);
        }

        public Task<Vehiculo> ObtenerVehiculoPorIdAsync(Guid id)
        {
            return _vehiculosCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerTodosVehiculosAsync()
        {
            var cursor = await _vehiculosCollection.FindAsync(_ => true);
            return await cursor.ToListAsync();
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerVehiculosDisponiblesAsync()
        {
            var cursor = await _vehiculosCollection.FindAsync(v => !v.Alquilado);
            return await cursor.ToListAsync();
        }

        public async Task ActualizarVehiculoAsync(Vehiculo vehicle)
        {
            await _vehiculosCollection.ReplaceOneAsync(v => v.Id == vehicle.Id, vehicle);
        }
    }
}
