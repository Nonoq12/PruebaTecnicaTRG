using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Interfaz repositorio Cliente.
    /// </summary>
    public interface IClienteRepository
    {
        /// <summary>
        /// Agregar nuevo cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        Task AgregarClienteAsync(Cliente cliente);

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Cliente> ObtenerClientePorIdAsync(Guid id);

        /// <summary>
        /// Obtiene la lista de todos los clientes.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Cliente>> ObtenerTodosClientesAsync();

    }
}
