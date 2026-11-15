using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Repositories
{
    /// <summary>
    /// Interfaz repositorio Alquiler.
    /// </summary>
    public interface IAlquilerRepository
    {
        /// <summary>
        /// Agregar nuevo alquiler.
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        Task AgregarAlquilerAsync(Alquiler alquiler);

        /// <summary>
        /// Obtiene un alquiler por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Alquiler> ObtenerAlquilerPorIdAsync(Guid id);

        /// <summary>
        /// Obtiene la lista de todos los alquileres.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Alquiler>> ObtenerTodosAlquilersAsync();

        /// <summary>
        /// Obtiene la lista de los alquileres sin terminar.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Alquiler>> ObtenerPendientesAlquilersAsync();

        /// <summary>
        /// Obtiene la lista de los alquileres terminados.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Alquiler>> ObtenerTerminadosAlquilersAsync();

        /// <summary>
        /// Actualizar un alquiler.
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        Task ActualizarAlquilerAsync(Alquiler alquiler);

        /// <summary>
        /// Borrar un alquiler.
        /// </summary>
        /// <param name="alquiler"></param>
        /// <returns></returns>
        Task BorrarAlquilerAsync(Alquiler alquiler);

    }
}
