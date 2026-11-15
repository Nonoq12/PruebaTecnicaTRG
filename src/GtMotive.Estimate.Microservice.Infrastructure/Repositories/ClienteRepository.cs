using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Repositories;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de Clientes.
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        // Recibe el servicio de Mongo ya configurado
        public ClienteRepository(IMongoDatabase database)
        {
            ArgumentNullException.ThrowIfNull(database);
            _clientesCollection = database.GetCollection<Cliente>("Clientes");
        }

        public async Task AgregarClienteAsync(Cliente cliente)
        {
            await _clientesCollection.InsertOneAsync(cliente);
        }

        public Task<Cliente> ObtenerClientePorIdAsync(Guid id)
        {
            return _clientesCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosClientesAsync()
        {
            // Realiza una consulta para traer todos los documentos de la colección
            var cursor = await _clientesCollection.FindAsync(_ => true);
            return await cursor.ToListAsync();
        }
    }
}
